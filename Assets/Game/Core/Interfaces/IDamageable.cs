using System;

public interface IDamageable
{ 
  public event Action DamageRecived;
  public event Action<int> HealthChanged;
  
  public event Action PlayerDied;
  
  void TakeDamage(int damage);
}
