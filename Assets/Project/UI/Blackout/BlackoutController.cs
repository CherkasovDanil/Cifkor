using System;
using DG.Tweening;
using Project.UI.Blackout;
using UI.Main;

namespace UI.Blackout
{
    public class BlackoutController : IBlackoutController
    {
        private Tween _tween;
        private BlackoutView _blackoutView;

        private readonly BlackoutView.Pool _blackoutViewPool;
        private readonly IUIRoot _uiRoot;

        private const float Duration = 0.75f;
        
        public BlackoutController(
            BlackoutView.Pool blackoutViewPool,
            IUIRoot uiRoot)
        {
            _blackoutViewPool = blackoutViewPool;
            _uiRoot = uiRoot;
            
            _blackoutView = _blackoutViewPool.Spawn();
            _blackoutView.transform.SetParent(_uiRoot.Container.Layers[4], false);
            _blackoutView.ResetRectTransform();
            _blackoutView.gameObject.SetActive(false);
        }

        public void FadeIn(Action onEnd = null)
        {
            Fade(1f, onEnd);
        }

        public void FadeOut(Action onEnd = null)
        {
            onEnd += Disable;
            
            Fade(0f, onEnd);
        }

        private void Disable()
        {
            _blackoutView.gameObject.SetActive(false);
        }

        private void Fade(float value, Action onEnd, bool withoutDuration = false)
        {
            _tween?.Kill();
            _blackoutView.gameObject.SetActive(true);

            _tween = _blackoutView.BlackoutImage.DOFade(value, withoutDuration ? 0f : Duration).OnComplete(() =>
            {
                onEnd?.Invoke();
            });
        }
    }
}