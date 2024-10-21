using UnityEngine;

public class Resurection : MonoBehaviour
{
   [SerializeField] private Health _health;
   [SerializeField] private Movement _movement;
   [SerializeField] private Invulnerability _invulnerability;
   
   public void ResurectPlayer()
   {
      _health.Reset();
      _movement.SetPlayerInInitPosition();
      _invulnerability.EndInvulnerable();
   }


   public void RestoreHealth()
   {
      _health.Reset();
   }
}
