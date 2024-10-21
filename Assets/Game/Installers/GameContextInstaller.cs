using UnityEngine;
using Zenject;

public class GameContextInstaller : MonoInstaller
{   
    [SerializeField] private SpeedObjects _speedObjects;
    [SerializeField] private ValueRewards _valueRewards;
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private Storage _storage;
    [SerializeField] private Score _score;
    [SerializeField] private LevelManager _levelManager;
    
    public override void InstallBindings()
    {
        BindSpeedObjects();
        BindValueRewards();
        BindInputSystem();
        BindStorage();
        BindScore();
        BindLevelManager();
    }

    private void BindSpeedObjects()
    {
        Container.Bind<SpeedObjects>().FromInstance(_speedObjects).AsSingle();
    }
    
    private void BindValueRewards()
    {
        Container.Bind<ValueRewards>().FromInstance(_valueRewards).AsSingle();
    }
    
    private void BindInputSystem()
    {
        Container.Bind<InputSystem>().FromInstance(_inputSystem).AsSingle();
    }
    
    private void BindStorage()
    {
        Container.BindInterfacesAndSelfTo<Storage>().FromInstance(_storage).AsSingle();
    }
    
    private void BindScore()
    {
        Container.BindInterfacesAndSelfTo<Score>().FromInstance(_score).AsSingle();
    }
    
    private void BindLevelManager()
    {
        Container.BindInterfacesAndSelfTo<LevelManager>().FromInstance(_levelManager).AsSingle();
    }
}
