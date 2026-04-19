using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private RaycastReader _rayCastReader;
    [SerializeField] private Cube _cube;

    private int _minObjects = 2;
    private int _maxObjects = 6;
    private float _decreaseFactor = 0.5f;
    private static float  _splitChance = 1f;
    private List<Rigidbody> _childrenRigidBody = new List<Rigidbody>();

    public IReadOnlyList<Rigidbody> ChildrenObjects => _childrenRigidBody;

    public event Action Clonned;

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
        float minValue = 0f;
        float maxValue = 1f;
        float randomValue = Random.Range(minValue, maxValue);

        if (_cube.IsRoute)
        {
            Split(clickedObject);
            _cube.ChangeState();
        }
        else
        {
            if(randomValue <= _splitChance)
            {
                Split(clickedObject);
                _splitChance *= _decreaseFactor;
            }
        }

        Clonned?.Invoke();
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
