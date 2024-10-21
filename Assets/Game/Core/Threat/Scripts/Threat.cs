using UnityEngine;

public class Threat : MonoBehaviour
{
   [SerializeField] private int _damage;

   private void OnTriggerEnter2D(Collider2D other)
   {
       var damageable = other.GetComponent<Entity>().GetComponentImplementing<IDamageable>();
       if (damageable != null)
       {
           damageable.TakeDamage(_damage);
           Destroy(gameObject);
       }
   }
   
}
