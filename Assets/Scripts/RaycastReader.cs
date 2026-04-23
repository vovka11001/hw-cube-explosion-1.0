using UnityEngine;
using System;

public class RaycastReader : MonoBehaviour
{
    private Camera _camera;
    public event Action<Cube> HittedObject;

    private void Start()
    {
        _camera = Camera.main;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity,~0, QueryTriggerInteraction.Ignore))
            {
                Cube cube = hit.collider.GetComponent<Cube>();
            
                if (cube != null)
                {
                    HittedObject?.Invoke(cube);
                }
            } 
        }
    }
}
