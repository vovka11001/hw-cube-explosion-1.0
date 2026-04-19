using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private RaycastReader _rayCastReader;
    private Cube _cube;
    private Cube _newCubeScript;

    private int _minObjects = 2;
    private int _maxObjects = 6;
    private List<Rigidbody> _childrenRigidBody = new List<Rigidbody>();

    public IReadOnlyList<Rigidbody> ChildrenObjects => _childrenRigidBody;

    public event Action<Vector3> Clonned;

    private void OnEnable()
    {
        _rayCastReader.HittedObject += Clone;
    }

    private void OnDisable()
    {
        _rayCastReader.HittedObject -= Clone;
    }

    private void Clone(GameObject clickedObject)
    {
        _cube = clickedObject.GetComponent<Cube>();
        Vector3 explosionCenter = _cube.transform.position;

        float minValue = 0f;
        float maxValue = 1f;
        float randomValue = Random.Range(minValue, maxValue);

        if (_cube.IsRoute)
        {
            Split(clickedObject);
        }
        else
        {
            if(randomValue <= _newCubeScript.SplitChance)
            {
                Split(clickedObject);
                _newCubeScript.ChangeChance();
            }
        }

        Clonned?.Invoke(explosionCenter);
        Destroy(clickedObject);
    }

    private void Split(GameObject clickedObject)
    {
        int numberOfObjects = GetRandomRange();
        float dicreaseScale = 0.5f;

        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject newCube = Instantiate(clickedObject);
            
            newCube.transform.localScale *= dicreaseScale;

            _newCubeScript = newCube.GetComponent<Cube>();

            if (_newCubeScript != null)
            {
                _newCubeScript.ChangeState();
            }

            Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();

            if (cubeRigidbody != null)
            {
                _childrenRigidBody.Add(cubeRigidbody);
            }
        }
    }

    private int GetRandomRange()
    {
        return Random.Range(_minObjects, _maxObjects + 1);
    }
}
