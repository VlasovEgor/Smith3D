
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UIHealth _uiHealth;
    [SerializeField] private UIScore _uiScore;
    [SerializeField] private Menu _menu;
    [FormerlySerializedAs("_resurrection")] [SerializeField] private ResurrectionUI resurrectionUI;
    
    public override void InstallBindings()
    {
        BindHealth();
        BindScore();
        BindMenu();
        BindResurrection();
    }

    private void BindHealth()
    {
        Container.BindInterfacesAndSelfTo<UIHealth>().FromInstance(_uiHealth).AsSingle();
    }
    
    private void BindScore()
    {
        Container.BindInterfacesAndSelfTo<UIScore>().FromInstance(_uiScore).AsSingle();
    }
    
    private void BindMenu()
    {
        Container.Bind<Menu>().FromInstance(_menu).AsSingle();
    }
    
    private void BindResurrection()
    {
        Container.Bind<ResurrectionUI>().FromInstance(resurrectionUI).AsSingle();
    }
}
