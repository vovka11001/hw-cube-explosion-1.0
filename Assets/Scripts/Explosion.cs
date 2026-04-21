using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Spawner _spawner;

    private void ExplodeChildrens(Cube cube)
    {
        foreach (var childrenObject in _spawner.ChildrenObjects)
        {
            if (childrenObject != null)
            {
                childrenObject.AddExplosionForce(_explosionForce,cube.transform.position,_explosionRadius);
            }
        }
    }

    private void ExplodeAll(Cube cube)
    {
        Collider[] hitColliders = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        foreach (var hitCollider in hitColliders)
        {
            Rigidbody rigidbody = hitCollider.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce * cube.Scale,cube.transform.position,_explosionRadius * cube.Scale);
            }
        }
    }

    public void ExplodeHandler(Cube cube)
    {
        if(cube.IsSplit)
        {
            ExplodeChildrens(cube);
        }
        else
        {
            ExplodeAll(cube);
        }
    }
}