using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private TypeReward _type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Entity>(out var entity))
        {
            var storage = entity.GetComponentImplementing<Bag>();
            if (storage != null)
            {
                storage.AddReward(_type);
                Destroy(gameObject);
            }
        }
    }
}
