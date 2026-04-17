using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    private Ray _ray;
    private Camera _camera;
    private RaycastHit _hit;
    private CubeSplit _cubeSplit;
    
    public event Action<GameObject> HittedObject;

    private void Start()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                _cubeSplit = _hit.collider.GetComponent<CubeSplit>();
            
                if (_cubeSplit != null)
                {
                    HittedObject?.Invoke(_hit.collider.gameObject);
                }
            } 
        }
    }
}
