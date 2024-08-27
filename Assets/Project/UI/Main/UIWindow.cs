using System;
using UnityEngine;

namespace UI.Main
{
    public abstract class UIWindow : MonoBehaviour, IUIWindow
    {
        public EventHandler ShowEvent { get; set; }
        public EventHandler HideEvent { get; set; }
        public abstract void Show();
        public abstract void Hide();
        
        protected virtual void OnShowEnd() { }
        protected virtual void OnHideEnd() { }
    }
}