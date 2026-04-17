using UnityEngine;

public class Explosion : MonoBehaviour
{
   [SerializeField] private CubeSplit _cubeSplit;
   [SerializeField] private float _explosionRadius;
   [SerializeField] float _explosionForce;

   private void OnEnable()
   {
       _cubeSplit.Clonned += Explode;
   }

   private void OnDisable()
   {
       _cubeSplit.Clonned -= Explode;
   }
   
   private void Explode()
   {
       foreach (var childrenObject in _cubeSplit.ChildrenObjects)
       {
           if (childrenObject != null)
           {
               childrenObject.AddExplosionForce(_explosionForce,_cubeSplit.ObjectPosition,_explosionRadius);
           }
       }
   }
}
