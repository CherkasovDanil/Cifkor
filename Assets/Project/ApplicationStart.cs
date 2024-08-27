using Project.Camera;
using Project.UI.Blackout;
using UI.Main;

namespace Project
{
    public class ApplicationStart
    {
        public ApplicationStart(
            CameraController cameraController,
            IUIService uiService,
            IBlackoutController blackoutController)
        {
            blackoutController.FadeIn(() =>
            {
                cameraController.SetCamera();
                
                uiService.Show<UIPlayingScene>();
                
                blackoutController.FadeOut();
            });
        }
    }
}