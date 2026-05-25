using OVERLIMIT.Core.Config;
using OVERLIMIT.Core.Input;
using OVERLIMIT.Core.Messages.City;
using OVERLIMIT.Utility.Logging;
using OVERLIMIT.Utility.Validation;
using UnityEngine;

namespace OVERLIMIT.Features.City.Car
{
    /// <summary>
    /// Custom arcade car controller using raycast suspension
    /// and physics-based Rigidbody movement.
    /// </summary>
    public class CarController : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField]
        private CarPhysicConfig _config;

        [SerializeField]
        private LayerMask _groundLayer; // Layer mask defining drivable surfaces (track, terrain, obstacles).

        [Header("Raycast wheels")]
        [SerializeField]
        private Transform FL; // Front left

        [SerializeField]
        private Transform FR; // Front right

        [SerializeField]
        private Transform RL; // Rear left

        [SerializeField]
        private Transform RR; // Rear right

        private Rigidbody _rb; // Physics body reference
        private CarInput _input; // Input system action wrapper

        // Caching input axes (range from -1.0 to 1.0)
        private float _throttleInput;
        private float _steeringInput;

        // Initializes core components and dependencies on script creation.
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _input = new CarInput();
        }

        // Validates that all required object references and components are assigned.
        private void Start()
        {
            if (this.BeginValidation().Require(_rb, nameof(_rb)).LogAndCheck())
                return;
        }

        // Enables/Disables the input map listener to prevent memory leaks and handle background state.
        private void OnEnable() => _input.ArcadeCar.Enable();

        private void OnDisable() => _input.ArcadeCar.Disable();

        // Polls and caches the raw player movement input every frame.
        private void Update()
        {
            Vector2 inputValue = _input.ArcadeCar.Movement.ReadValue<Vector2>();

            _throttleInput = inputValue.y; // WS
            if (inputValue.y != 0)
                OverLogger.LogSuccess(CarMsg.MovingByY);

            _steeringInput = inputValue.x; //AD
            if (inputValue.x != 0)
                OverLogger.LogSuccess(CarMsg.TurnByX);
        }

        // Executes physics calculations at a fixed time interval.
        private void FixedUpdate()
        {
            Vector3 rayDirection = -transform.up;

            // Physics.Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
            bool isFLGrounded = Physics.Raycast(
                origin: FL.position,
                direction: rayDirection,
                maxDistance: _config.suspensionRestLength,
                hitInfo: out RaycastHit hitFL,
                layerMask: _groundLayer
            );

            bool isFRGrounded = Physics.Raycast(
                origin: FR.position,
                direction: rayDirection,
                maxDistance: _config.suspensionRestLength,
                hitInfo: out RaycastHit hitFR,
                layerMask: _groundLayer
            );

            bool isRLGrounded = Physics.Raycast(
                origin: RL.position,
                direction: rayDirection,
                maxDistance: _config.suspensionRestLength,
                hitInfo: out RaycastHit hitRL,
                layerMask: _groundLayer
            );

            bool isRRGrounded = Physics.Raycast(
                origin: RR.position,
                direction: rayDirection,
                maxDistance: _config.suspensionRestLength,
                hitInfo: out RaycastHit hitRR,
                layerMask: _groundLayer
            );
        }
    }
}
