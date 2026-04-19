using UnityEngine;

public class ColorChanger : MonoBehaviour
{
   [SerializeField] private Spawner _spawner;

    private void OnTriggerEnter(Collider other)
    {
        foreach (Rigidbody rigidbody in _spawner.ChildrenObjects)
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
