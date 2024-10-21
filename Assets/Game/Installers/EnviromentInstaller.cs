using UnityEngine;
using Zenject;

public class EnviromentInstaller : MonoInstaller
{
    [SerializeField] private SegmentsSpawner _segmentsSpawner;
    
    public override void InstallBindings()
    {
        BindSegmentsSpawner();
    }

    private void BindSegmentsSpawner()
    {
        Container.BindInterfacesAndSelfTo<SegmentsSpawner>().FromInstance(_segmentsSpawner).AsSingle();
    }
}
