using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event Action DamageRecived;
    public event Action<int> HealthChanged;
    public event Action PlayerDied;
    
    [SerializeField] private int _maxHealt;
    [SerializeField] private Invulnerability _invulnerability;
    [SerializeField] private Movement _movement;

    private int _currentHealth;

    private Vector3 topRight;
    private Vector3 bottomLeft;
    
    void Start()
    {
        _currentHealth = _maxHealt;
        HealthChanged?.Invoke(_currentHealth);
        
    }
    

    public void TakeDamage(int damage)
    {
        if (_invulnerability.Invulnerable)
        {
            return;
        }
        
        if (damage < 0)
        {
            return;
        }

        _currentHealth -= damage;
        
        HealthChanged?.Invoke(_currentHealth);
        DamageRecived?.Invoke();

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Death();
        }
    }

    public void TakeBorderDamage(int damage)
    {
        TakeDamage(damage);
        _movement.SetPlayerInInitPosition();
    }

    private void Death()
    {   
        PlayerDied?.Invoke();
    }

    public void Reset()
    {
        _currentHealth = _maxHealt;
        HealthChanged?.Invoke(_currentHealth);
    }
}
