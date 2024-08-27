using System;
using Project.Clicker;
using UI.Main;

namespace Project.UI.Controllers
{
    public class UIPlayingSceneController
    {
        private readonly ClickController _clickController;
        
        private UIPlayingScene _uiPlayingScene;
        
        public UIPlayingSceneController(
            IUIService uiService,
            ClickController clickController)
        {
            _clickController = clickController;
            _uiPlayingScene = uiService.Get<UIPlayingScene>();

            _uiPlayingScene.OnTapButtonClickEvent += TapLogic;
        }

        private void TapLogic(object sender, EventArgs e)
        {
            _clickController.Click();
        }
    }
}