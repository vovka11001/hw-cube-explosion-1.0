using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class CubeSplit : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Explosion _explosion;

    private int _minCubes = 2;
    private int _maxCubes = 6;
    private static float _splitChance = 1f;
    private float _decreaseFactor = 0.5f;
    private List<Rigidbody> _childrenRigidBody = new List<Rigidbody>();
    
    public IReadOnlyList<Rigidbody> ChildrenObjects => _childrenRigidBody;
    public Vector3 ObjectPosition => transform.position;

    public event Action Clonned;

    private void OnEnable()
    {
        _inputReader.HittedObject += HandleReader;
    }

    private void OnDisable()
    {
        _inputReader.HittedObject -= HandleReader;
    }

    private void HandleReader(GameObject clickedObject)
    {
        if (clickedObject != gameObject)
            return;
        
        Clone();
        Destroy(clickedObject);
    }

    private void Clone()
    {
        float minValue = 0f;
        float maxValue = 1f;
        float randomValue = Random.Range(minValue, maxValue);
        
        if (randomValue <= _splitChance)
        {
            int numberOfObjects = GetRandomRange();
            float dicreaseScale = 0.5f;
            
            for (int i = 0; i < numberOfObjects; i++)
            {
                GameObject newCube = Instantiate(gameObject);
                newCube.transform.localScale *= dicreaseScale;
                
                Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();
                
                if (cubeRigidbody != null)
                {
                    _childrenRigidBody.Add(cubeRigidbody);
                }
            }
        }
        
        Clonned?.Invoke();
        _splitChance *= _decreaseFactor;
    }
    
    private int GetRandomRange()
    {
        return Random.Range(_minCubes, _maxCubes + 1);
    }
}
