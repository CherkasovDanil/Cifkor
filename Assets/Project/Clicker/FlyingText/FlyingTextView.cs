using System;
using DG.Tweening;
using TMPro;
using UI.Main;
using UnityEngine;
using Zenject;

namespace Project.Clicker.FlyingText
{
    public struct FlyingProtocol
    {
        public Vector2 Position;
        public int Value;
    }
    
    public class FlyingTextView : MonoBehaviour, IPoolable<FlyingProtocol,IMemoryPool>
    {
        public event EventHandler<FlyingTextView> OnEndMovingEvent;
        
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private RectTransform rectTransform;

        private UIPlayingScene _uiPlayingScene;
        private ClickerSettings _clickerSettings;
        
        [Inject]
        private void Inject(
            IUIService uiService,
            ClickerSettings clickerSettings)
        {
            _uiPlayingScene = uiService.Get<UIPlayingScene>();
            _clickerSettings = clickerSettings;
        }
        
        public void OnDespawned()
        {
            rectTransform.localPosition = Vector3.zero;
            text.DOFade(1, 0);
        }

        public void OnSpawned(FlyingProtocol p1, IMemoryPool p2)
        {
            AnimateText();
        }
        
        private void AnimateText()
        {
            Vector3 targetPosition = transform.position + new Vector3(0, _clickerSettings.FlyDistance);

            transform
                .DOMove(targetPosition, _clickerSettings.AnimationDuration)
                .SetAutoKill();
            
            text
                .DOFade(0, _clickerSettings.AnimationDuration)
                .SetAutoKill()
                .OnComplete(() =>
                {
                    OnEndMovingEvent?.Invoke(null, this);
                });
        }
        
        public void ReInit(FlyingProtocol protocol)
        {
            transform.SetParent(_uiPlayingScene.transform, false);
            
            transform.position = protocol.Position;
            text.text = $"{protocol.Value}";
        }
        
        public class Pool : MonoMemoryPool<FlyingProtocol, FlyingTextView>
        {
            protected override void Reinitialize(FlyingProtocol bonusModel, FlyingTextView item)
            {
                item.ReInit(bonusModel);
                item.OnSpawned(bonusModel, this);
            }

            protected override void OnDespawned(FlyingTextView item)
            {
                base.OnDespawned(item);
                item.OnDespawned();
            }
        }
    }
}