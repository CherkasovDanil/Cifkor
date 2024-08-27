using System;

namespace Project.UI.Blackout
{
    public interface IBlackoutController
    {
        void FadeIn(Action onEnd = null);
        void FadeOut(Action onEnd = null);
    }
}