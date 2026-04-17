using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class CubeSplit : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

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
        Clone();
        Destroy(clickedObject);
    }

    private void Clone()
    {
        Instantiate(gameObject);
        Clonned?.Invoke();
    }
}
