using OVERLIMIT.Core.Messages.City;
using OVERLIMIT.Utility.Logging;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OVERLIMIT.Features.City.Car
{
    /// <summary>
    /// Управление машиной
    /// </summary>
    public class CarController : MonoBehaviour
    {
        private void Update()
        {
            if (Keyboard.current.wKey.isPressed)
                OverLogger.LogSuccess(CarMsg.PressedButtonForward);

            if (Keyboard.current.sKey.isPressed)
                OverLogger.LogSuccess(CarMsg.PressedButtonBack);

            if (Keyboard.current.aKey.isPressed)
                OverLogger.LogSuccess(CarMsg.PressedButtonLeft);

            if (Keyboard.current.dKey.isPressed)
                OverLogger.LogSuccess(CarMsg.PressedButtonRight);
        }

        private void FixedUpdate() { }
    }
}
