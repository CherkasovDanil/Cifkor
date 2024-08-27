using UnityEngine;

namespace UI.Main
{
    public class LayerContainer : MonoBehaviour
    {
        public Transform[] Layers => layers;
        
        [SerializeField] private Transform[] layers;
    }
}