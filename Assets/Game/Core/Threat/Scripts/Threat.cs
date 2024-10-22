using UnityEngine;

public class Threat : MonoBehaviour
{
   [SerializeField] private int _damage;

   private void OnTriggerEnter(Collider other)
   {
       
       if (other.TryGetComponent<Entity>(out var entity))
       {
           var damageable = entity.GetComponentImplementing<IDamageable>();
           if (damageable != null)
           {
               damageable.TakeDamage(_damage);
               Destroy(gameObject);
           }
       }
   }
}
