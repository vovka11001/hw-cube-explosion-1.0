using UnityEngine;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void ExplodeChildrens(Cube cube, IReadOnlyList<Rigidbody> objets)
    {
        foreach (var childrenObject in objets)
        {
            if (childrenObject != null)
            {
                childrenObject.AddExplosionForce(_explosionForce,cube.transform.position,_explosionRadius);
            }
        }
    }

    private void ExplodeAll(Cube cube)
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

    public void ExplodeHandler(Cube cube,IReadOnlyList<Rigidbody> objets)
    {
        if(cube.IsSplit)
        {
            ExplodeChildrens(cube,objets);
        }
        else
        {
            ExplodeAll(cube);
        }
    }
}