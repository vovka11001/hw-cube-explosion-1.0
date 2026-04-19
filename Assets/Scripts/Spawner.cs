using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private RaycastReader _rayCastReader;

    private int _minObjects = 2;
    private int _maxObjects = 6;
    private List<Rigidbody> _childrenRigidBody = new List<Rigidbody>();
    public IReadOnlyList<Rigidbody> ChildrenObjects => _childrenRigidBody;
    public void Clone(Cube cube)
    {
        float minValue = 0f;
        float maxValue = 1f;
        float randomValue = Random.Range(minValue, maxValue);

        if (randomValue <= cube.SplitChance)
        {
            Split(cube);
        }

        Destroy(cube.gameObject);
    }

    private void Split(Cube cube)
    {
        int numberOfObjects = GetRandomRange();
        float dicreaseScale = 0.5f;

        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject newCube = Instantiate(cube.gameObject);
            
            newCube.transform.localScale *= dicreaseScale;

            Cube newCubeScript = newCube.GetComponent<Cube>();

            if (newCubeScript != null)
            {
                newCubeScript.SetChance(cube.ChangeChance());
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
