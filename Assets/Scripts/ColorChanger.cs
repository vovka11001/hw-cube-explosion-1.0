using UnityEngine;
using System.Collections.Generic;

public class ColorChanger : MonoBehaviour
{
    public void Recolor(List<Rigidbody> objects)
    {
        foreach (var rigidbody in objects)
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
