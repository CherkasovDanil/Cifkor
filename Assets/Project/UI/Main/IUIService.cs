using System;
using UnityEngine;

namespace UI.Main
{
    public interface IUIService
    {
        T Show<T>(int layer = 0) where T : UIWindow;

        void Hide<T>(Action onEnd = null) where T : UIWindow;

        T Get<T>() where T : UIWindow;

        void InitWindows(Transform poolDeactiveContiner = null);

        void LoadWindows(string source);
    }
}