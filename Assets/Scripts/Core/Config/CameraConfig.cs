using UnityEngine;

namespace OVERLIMIT.Core.Config
{
    /// <summary>
    /// Defaul player camera parameters.
    /// </summary>
    [CreateAssetMenu(fileName = "NewCameraConfig", menuName = "OVERLIMIT/Camera Config")]
    public class CameraConfig : ScriptableObject
    {
        [Header("Параметры позиции камеры")]
        public float indent = 200f; // Дистанция назад
        public float height = 45f; // Высота над машиной
    }
}
