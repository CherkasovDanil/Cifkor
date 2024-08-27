using Project.Camera;
using UnityEngine;

namespace Project.Clicker.FlyingText
{
    public class FlyingTextController
    {
        private readonly FlyingTextView.Pool _pool;
        private readonly CameraController _cameraController;
        private readonly ClickerSettings _clickerSettings;

        private FlyingProtocol _flyingProtocol;

        public FlyingTextController(
            FlyingTextView.Pool pool,
            CameraController cameraController,
            ClickerSettings clickerSettings)
        {
            _pool = pool;
            _cameraController = cameraController;
            _clickerSettings = clickerSettings;
        }
        
        public void Spawn()
        {
            _flyingProtocol.Position = _cameraController.CameraView.Camera.ScreenToWorldPoint(Input.mousePosition);;
            _flyingProtocol.Value = _clickerSettings.BaseCurrencyPerTap;
            
           var view =  _pool.Spawn(_flyingProtocol);
           view.OnEndMovingEvent += Despawn;
        }

        private void Despawn(object sender, FlyingTextView view)
        {
            view.OnEndMovingEvent -= Despawn;
            _pool.Despawn(view);
        }
    }
}