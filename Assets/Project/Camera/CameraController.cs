using UI.Main;
using Zenject;

namespace Project.Camera
{
    public class CameraController
    {
        public CameraView CameraView => _cameraView;
        
        private readonly IInstantiator _instantiator;
        private readonly IUIRoot _uiRoot;

        private CameraView _cameraView;
        
        public CameraController(
            IInstantiator instantiator,
            IUIRoot uiRoot)
        {
            _instantiator = instantiator;
            _uiRoot = uiRoot;
        }

        public void SetCamera()
        {
            _cameraView =  _instantiator.InstantiatePrefabResourceForComponent<CameraView>("MainCamera");
            
            _uiRoot.Camera = _cameraView.Camera;
            _uiRoot.Canvas.worldCamera = _cameraView.Camera;
            _uiRoot.Canvas.planeDistance = 1;
        }
    }
}