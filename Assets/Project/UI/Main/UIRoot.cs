using UnityEngine;

namespace UI.Main
{
    public class UIRoot : MonoBehaviour ,IUIRoot
    {
        public Camera Camera { get; set; }
        
        public LayerContainer Container => container;

        public Transform PoolContainer => poolContainer;

        public Canvas Canvas
        {
            get => canvas;
            set => canvas = value;
        }
        
        [SerializeField] private Canvas canvas;
        [SerializeField] private LayerContainer container;
        [SerializeField] private Transform poolContainer;
    }
}