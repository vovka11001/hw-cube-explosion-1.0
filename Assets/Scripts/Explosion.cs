using UnityEngine;

public class Explosion : MonoBehaviour
{
   [SerializeField] private float _explosionRadius;
   [SerializeField] private float _explosionForce;
   [SerializeField] private Spawner _spawner;

   public void Explode(Cube cube)
   {
       foreach (var childrenObject in _spawner.ChildrenObjects)
       {
           if (childrenObject != null)
           {
               childrenObject.AddExplosionForce(_explosionForce,cube.transform.position,_explosionRadius);
           }
       }
   }
}
