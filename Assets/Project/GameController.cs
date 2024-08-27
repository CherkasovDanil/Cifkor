using Project.Camera;
using Project.UI.Blackout;
using UI.Main;

namespace Spider
{
    public class GameController
    {
        private readonly IBlackoutController _blackoutController;
        private readonly IUIService _uiService;
        private readonly CameraController _cameraController;

        private bool _seccionIsDone;

        public GameController(
            IBlackoutController blackoutController,
            IUIService uiService,
            CameraController cameraController)
        {
            _blackoutController = blackoutController;
            _uiService = uiService;
            _cameraController = cameraController;
        }
        
        public void StartGame()
        {
            _blackoutController.FadeIn(() =>
            {
                
                _blackoutController.FadeOut();
            });
        }
    }
}