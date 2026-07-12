using OVERLIMIT.Core.Config;
using OVERLIMIT.Utility.Validation;
using UnityEngine;

namespace OVERLIMIT.Features.City.Camera
{
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        /// Manages camera movement, smoothly tracking the vehicle from behind based on configuration parameters.
        /// </summary>
        [Header("Camera settings")]
        [SerializeField]
        private CameraConfig cameraConfig; // Configuration asset for distance and offset settings.

        [SerializeField]
        private Transform cameraTarget; // The target vehicle or object to follow.

        void Start()
        {
            // Dependency validation chain.
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
            // Calculates the tracking point using the target's position, inverse forward direction (distance), and up vector (height).
            // This guarantees the camera always frames the vehicle perfectly from behind.
            Vector3 targetPosition =
                cameraTarget.position
                - (cameraTarget.forward * cameraConfig.indent)
                + (cameraTarget.up * cameraConfig.height);
            transform.position = targetPosition;
        }
    }
}
