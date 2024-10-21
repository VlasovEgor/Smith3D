using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Entity _entity;
    
    public override void InstallBindings()
    {
        BindEntity();
    }

    private void BindEntity()
    {
        Container.Bind<Entity>().FromInstance(_entity).AsSingle();
    }
}
