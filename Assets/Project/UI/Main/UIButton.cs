using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class UIButton : MonoBehaviour, IPointerClickHandler
    {
        public event EventHandler OnClickEvent;
        public bool IsUsingByActive
        {
            get => isUsingByActive;
            set => isUsingByActive = value;
        }

        [SerializeField] private Sprite[] defaultSprites;
        [SerializeField] private Color defaultSpriteColor = Color.white;
        [SerializeField] private Color defaultTextColor = Color.white;
        [SerializeField] private Image[] sources;

        [SerializeField] private bool useSprite = true;
        [SerializeField] private Sprite click;

        [SerializeField] private TextMeshProUGUI textTMP;
        [SerializeField] private Image icon;
        [SerializeField] private Color clickColor;

        [SerializeField] private bool useColor;
        [SerializeField] private Color clickImageColor;

        [SerializeField] private bool useColorOnDisable;
        [SerializeField] private Color disableImageColor;
        [SerializeField] private Color disableTextColor;

        [SerializeField] private bool useSpriteOnDisable;
        [SerializeField] private Sprite[] disableSprites;

        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private bool isUsingByActive;
        
        private const float ClickVisualsTime = 0.1f;
        private const float FadedValue = 0.7f;
        private const float NormalFadedValue = 1f;
        private const float FadeDuration = 0.3f;
        private const string ButtonPressedSoundPath = "ButtonPressed";
        
        private Tween _clickDelayTween;
        private bool _isActive = true;
        
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (!_isActive)
            {
                return;
            }

            if (useSprite && sources != null)
            {
                foreach (var source in sources)
                {
                    source.sprite = click;
                }
            }

            if (useColor && textTMP != null) textTMP.color = clickColor;
            if (useColor && sources != null)
            {
                foreach (var source in sources)
                {
                    source.color = clickImageColor;
                }
            }

            _clickDelayTween?.Kill();
            _clickDelayTween = null;

            _clickDelayTween = DOVirtual.DelayedCall(ClickVisualsTime, () =>
            {
                if (useSprite && sources != null)
                {
                    for (int i = 0; i < sources.Length; i++)
                    {
                        sources[i].sprite = defaultSprites[i];
                    }
                }
                if (useColor && textTMP != null) textTMP.color = defaultTextColor;
                if (useColor && sources != null)
                {
                    foreach (var source in sources)
                    {
                        source.color = defaultSpriteColor;
                    }
                }
                
                _clickDelayTween?.Kill();
                _clickDelayTween = null;
                
                OnClickEvent?.Invoke(this, EventArgs.Empty);
            });
        }
        
        public void SetActive(bool value, UIButton button = null)
        {
            if (useColorOnDisable)
            {
                if (value)
                {
                    foreach (var source in sources)
                    {
                        source.color = defaultSpriteColor;
                    }
                    
                    if (textTMP != null)
                    {
                        textTMP.color = defaultTextColor;
                    }

                    if (icon != null)
                    {
                        icon.color = defaultTextColor;
                    }
                }
                else
                {
                    foreach (var source in sources)
                    {
                        source.color = disableImageColor;
                    }
                    
                    if (textTMP != null)
                    {
                        textTMP.color = disableTextColor;
                    }
                    
                    if (icon != null)
                    {
                        icon.color = disableTextColor;
                    }
                }
            }
            if (useSpriteOnDisable)
            {
                if (value)
                {
                    for (int i = 0; i < sources.Length; i++)
                    {
                        sources[i].sprite = defaultSprites[i];
                    }
                }
                else
                {
                    for (int i = 0; i < sources.Length; i++)
                    {
                        sources[i].sprite = disableSprites[i];
                    }
                }
            }
            
            if (canvasGroup != null)
            {
                if (!value)
                {
                    canvasGroup.DOFade(FadedValue, FadeDuration);
                }
                else
                {
                    canvasGroup.DOFade(NormalFadedValue, FadeDuration);
                }
            }
            
            _isActive = value;
        }
    }
}