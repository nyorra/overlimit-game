using OVERLIMIT.Core.Config;
using OVERLIMIT.Utility.Validation;
using UnityEngine;

namespace OVERLIMIT.Features.City.Camera
{
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        /// Контроллер для камеры
        /// </summary>
        [Header("Ссылки")]
        [SerializeField]
        private CameraConfig cameraConfig; // Ссылка на файл настроек

        [SerializeField]
        private Transform cameraTarget; // ссылка для передачи объекта привязки камеры

        void Start()
        {
            // Проверяем на null
            if (
                this.BeginValidation()
                    .Require(cameraConfig, nameof(cameraConfig))
                    .Require(cameraTarget, nameof(cameraTarget))
                    .LogAndCheck()
            )
                return;
        }

        private void LateUpdate()
        {
            //.position вектор x,y,z. .forward определяет взгляд машины по x y z. в результате камера всега в жопе
            Vector3 targetPosition =
                cameraTarget.position
                - (cameraTarget.forward * cameraConfig.indent)
                + (cameraTarget.up * cameraConfig.height);
            transform.position = targetPosition;
        }
    }
}
