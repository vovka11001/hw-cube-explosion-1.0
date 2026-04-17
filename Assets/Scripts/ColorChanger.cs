using UnityEngine;

public class ColorChanger : MonoBehaviour
{
   [SerializeField] private CubeSplit _cubeSplit;
    
    private void OnTriggerEnter(Collider other)
    {
        foreach (Rigidbody rigidbody in _cubeSplit.ChildrenObjects)
        {
            if (rigidbody != null)
            {
                Renderer renderer = rigidbody.GetComponent<Renderer>();
                
                if (renderer != null)
                {
                    renderer.material.color = Random.ColorHSV();
                }
            }
        }
    }
}
