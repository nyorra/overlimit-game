using UnityEngine;

namespace OVERLIMIT.Core.Config
{
    [CreateAssetMenu(fileName = "NewCameraConfig", menuName = "OVERLIMIT/Camera Config")]
    public class CameraConfig : ScriptableObject
    {
        [Header("Параметры позиции камеры")]
        public float indent = 150f; // Дистанция назад
        public float height = 2.3f; // Высота над машиной
    }
}
