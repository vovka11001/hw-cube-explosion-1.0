using UnityEngine;

public class Explosion : MonoBehaviour
{
   [SerializeField] private Cube _cube;
   [SerializeField] private float _explosionRadius;
   [SerializeField] private float _explosionForce;
   [SerializeField] private Spawner _spawner;

   private void OnEnable()
   {
        if( _spawner != null )
            _spawner.Clonned += Explode;
   }

   private void OnDisable()
   {
        if( _spawner != null )
            _spawner.Clonned -= Explode;
   }
   
   private void Explode(Vector3 explosionCenter)
   {
       foreach (var childrenObject in _spawner.ChildrenObjects)
       {
           if (childrenObject != null)
           {
               childrenObject.AddExplosionForce(_explosionForce,explosionCenter,_explosionRadius);
           }
       }
   }
}
