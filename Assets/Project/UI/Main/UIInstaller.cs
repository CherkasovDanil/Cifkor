using Platformer.UI;
using Project.UI.Blackout;
using Project.UI.Controllers;
using UI.Blackout;
using UI.Main;
using Zenject;

namespace Project.UI.Main
{
    public class UIInstaller : Installer<UIInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUIRoot>()
                .FromComponentInNewPrefabResource("UIRoot")
                .AsSingle();
            
            Container
                .Bind<IBlackoutController>()
                .To<BlackoutController>()
                .AsSingle();
            
            Container
                .Bind<UIPlayingSceneController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindMemoryPool<BlackoutView, BlackoutView.Pool>()
                .WithInitialSize(1)
                .FromComponentInNewPrefabResource("BlackoutView");

            Container
                .Bind<IUIService>()
                .To<UIService>()
                .AsSingle();
        }
    }
}