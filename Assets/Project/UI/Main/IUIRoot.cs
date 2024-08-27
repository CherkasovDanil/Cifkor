using UnityEngine;

namespace UI.Main
{
    public interface IUIRoot
    {
        Canvas Canvas { get; set; }
        Camera Camera { get; set; }
        LayerContainer Container { get; }
        Transform PoolContainer { get; }
    }
}