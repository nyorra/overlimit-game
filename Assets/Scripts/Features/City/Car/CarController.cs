using OVERLIMIT.Core.Input;
using OVERLIMIT.Core.Messages.City;
using OVERLIMIT.Utility.Logging;
using OVERLIMIT.Utility.Validation;
using UnityEngine;

namespace OVERLIMIT.Features.City.Car
{
    /// <summary>
    /// Управление машиной
    /// </summary>
    public class CarController : MonoBehaviour
    {
        private Rigidbody _rb;
        private CarInput _input;

        // Ввод кэшируем в float (оси от -1.0 до 1.0)
        private float _throttleInput; // Газ, тормоз
        private float _steeringInput; // Лево, право

        // Инициируем, awake запускается всего один раз
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _input = new CarInput();
        }

        private void Start()
        {
            if (this.BeginValidation().Require(_rb, nameof(_rb)).LogAndCheck())
                return;
        }

        private void OnEnable() => _input.ArcadeCar.Enable();

        private void OnDisable() => _input.ArcadeCar.Disable();

        // Считывает ввод игрока
        private void Update()
        {
            Vector2 inputValue = _input.ArcadeCar.Movement.ReadValue<Vector2>();

            _throttleInput = inputValue.y; // Газ (W/S)
            if (inputValue.y != 0)
                OverLogger.LogSuccess(CarMsg.MovingByY);

            _steeringInput = inputValue.x; //Руль (A/D)
            if (inputValue.x != 0)
                OverLogger.LogSuccess(CarMsg.TurnByX);
        }

        // Работает в фиксированных кадрах, тут физика
        private void FixedUpdate()
        {
            Vector3 forwardForce = transform.forward * _throttleInput * 30f;
            _rb.AddForce(forwardForce, ForceMode.Acceleration);
            if (forwardForce != Vector3.zero)
                OverLogger.LogSuccess(CarMsg.AddedForce);

            Vector3 turnTorque = transform.up * _steeringInput * 30f;
            _rb.AddTorque(turnTorque, ForceMode.Acceleration);
            if (turnTorque != Vector3.zero)
                OverLogger.LogSuccess(CarMsg.AddedTorque);
        }
    }
}
