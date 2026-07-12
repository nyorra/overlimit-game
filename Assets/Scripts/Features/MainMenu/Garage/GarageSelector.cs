using System;
using System.Collections.Generic;
using OVERLIMIT.Core.Messages.MainMenu;
using OVERLIMIT.Utility.Logging;
using UnityEngine;

namespace OVERLIMIT.Features.MainMenu.Garage
{
    /// <summary>
    /// Manages zero-indexed vehicle selection and maintains the globally accessible active car configuration.
    /// </summary>
    public class GarageSelector : MonoBehaviour
    {
        public List<CarData> allCars;
        private int _currentIndex = 0;

        /// Triggered whenever the active vehicle selection changes.
        public static event Action<CarData> OnCarChanged;

        /// Globally accessible data reference of the currently selected vehicle.
        public static CarData SelectedCar { get; private set; }

        /// Shifts the selection index based on the input direction vector.
        public void SwitchCar(int direction)
        {
            if (allCars.Count == 0)
                return;

            // Implements infinite circular navigation through the vehicle collection using the modulo operator.
            _currentIndex = (_currentIndex + direction + allCars.Count) % allCars.Count;

            // Caches the active scriptable asset configuration based on the new index.
            SelectedCar = allCars[_currentIndex];

            OverLogger.LogSuccess(GarageMsg.Switched(SelectedCar.CarName), this);
            OnCarChanged?.Invoke(SelectedCar);
        }
    }
}
