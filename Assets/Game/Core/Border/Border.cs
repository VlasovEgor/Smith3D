
using UnityEngine;

public class Border : MonoBehaviour
{   
    [SerializeField] private int _damage = 1;
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.TryGetComponent<Entity>(out var entity))
        {
            var damageable = entity.GetComponentImplementing<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeBorderDamage(_damage);
            }
        }
    }
}
