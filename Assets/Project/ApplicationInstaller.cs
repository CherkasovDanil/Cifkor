using DG.Tweening;
using Project;
using Project.Camera;
using Project.Clicker;
using Project.Clicker.FlyingText;
using Project.UI.Main;
using Spider;
using Zenject;

public class ApplicationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        DOTween.Clear();
            
        Container
            .Bind<GameController>()
            .AsSingle()
            .NonLazy();
        
        Container
            .BindMemoryPool<FlyingTextView, FlyingTextView.Pool>()
            .FromComponentInNewPrefabResource("FlyingTestView")
            .UnderTransformGroup("FlyingTest");
        
        Container
            .Bind<ClickerSettings>()
            .FromScriptableObjectResource("ClickerSettings")
            .AsSingle();
            
        Container
            .Bind<CameraController>()
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<FlyingTextController>()
            .AsSingle()
            .NonLazy();
                    
        Container
            .Bind<ClickController>()
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<EnergyController>()
            .AsSingle()
            .NonLazy();
        
        UIInstaller.Install(Container);

        Container
            .Bind<ApplicationStart>()
            .AsSingle()
            .NonLazy();
    }
}