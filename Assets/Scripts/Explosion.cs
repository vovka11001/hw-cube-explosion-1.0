using UnityEngine;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void ExplodeChildrens(Cube cube, List<Rigidbody> childrenObjects)
    {
        foreach (var childrenObject in childrenObjects)
        {
            if (childrenObject != null)
            {
                childrenObject.AddExplosionForce(_explosionForce,cube.transform.position,_explosionRadius);
            }
        }
    }

    public void ExplodeAll(Cube cube)
    {
        Collider[] hitColliders = Physics.OverlapSphere(cube.transform.position, _explosionRadius * cube.IncreaseScaleFactor);

        foreach (var hitCollider in hitColliders)
        {
            Rigidbody rigidbody = hitCollider.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce * cube.IncreaseScaleFactor,cube.transform.position,_explosionRadius * cube.IncreaseScaleFactor);
            }
        }
    }
}