using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIHealth : MonoBehaviour, IInitializable, IDisposable
{
    [SerializeField] private GameObject _healthIconPrefab;
    
    private List<GameObject> _healthIcons = new();
    private IDamageable _playerDamageable;
    
    [Inject]
    public void Construct(Entity playerEntity)
    {
        _playerDamageable = playerEntity.GetComponentImplementing<IDamageable>();
    }
    
    public void Initialize()
    {
        _playerDamageable.HealthChanged += Setup;
    }
    
    public void Dispose()
    {
        _playerDamageable.HealthChanged -= Setup;
    }

    private void Setup(int health)
    {
        foreach (var icon in _healthIcons)
        {
            Destroy(icon);
        }
        
        _healthIcons.Clear();
        
        for (int i = 0; i < health; i++)
        {
            GameObject newIcon = Instantiate(_healthIconPrefab, transform);
            _healthIcons.Add(newIcon);
        }
    }
}
