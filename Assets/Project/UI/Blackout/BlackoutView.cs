using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.UI.Blackout
{
    public class BlackoutView : MonoBehaviour
    {
        public Image BlackoutImage => blackoutImage;
        
        [SerializeField] private Image blackoutImage;
        
        public void ResetRectTransform()
        {
            var viewTransform = transform;
            
            viewTransform.localPosition = Vector3.zero;
            viewTransform.localScale = Vector3.one;
        }
        
        public class Pool : MonoMemoryPool<BlackoutView>
        { }
    }
}