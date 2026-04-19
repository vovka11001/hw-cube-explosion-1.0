using UnityEngine;
using System;

public class RaycastReader : MonoBehaviour
{
    private Ray _ray;
    private Camera _camera;
    private RaycastHit _hit;
    private Cube _cube;
    
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

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity,~0, QueryTriggerInteraction.Ignore))
            {
                _cube = _hit.collider.GetComponent<Cube>();
            
                if (_cube != null)
                {
                    HittedObject?.Invoke(_cube.gameObject);
                }
            } 
        }
    }
}
