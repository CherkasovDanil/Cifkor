using UnityEngine;

namespace Project.Camera
{
    public class CameraView : MonoBehaviour
    {
        public UnityEngine.Camera Camera => camera;
        
        [SerializeField] private UnityEngine.Camera camera;
    }
}