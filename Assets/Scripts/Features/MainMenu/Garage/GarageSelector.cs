using System;
using System.Collections.Generic;
using UnityEngine;
using OVERLIMIT.Logging;
using OVERLIMIT.Messages;


namespace OVERLIMIT.Garage
{
    /// <summary>
    /// Выборка машины по индексу, с нуля
    /// </summary>
    public class GarageSelector : MonoBehaviour
    {
        public List<CarData> allCars;
        private int _currentIndex = 0;

        public static event Action<CarData> OnCarChanged;
        public static CarData SelectedCar { get; private set; }

        public void SwitchCar(int direction)
        {
            if (allCars.Count == 0) return;

            _currentIndex = (_currentIndex + direction + allCars.Count) % allCars.Count;
            SelectedCar = allCars[_currentIndex];

            OverLogger.LogSuccess(AppMessages.MainMenu.Garage.Switched(SelectedCar.CarName), this);
            OnCarChanged?.Invoke(SelectedCar);
        }

        public void Init()
        {
            if (allCars.Count == 0) return;

            if (SelectedCar == null)
            {
                _currentIndex = 0;
                SelectedCar = allCars[_currentIndex];
            }
            else
            {
                _currentIndex = allCars.IndexOf(SelectedCar);
                if (_currentIndex == -1) _currentIndex = 0;
            }

            OnCarChanged?.Invoke(SelectedCar);
            OverLogger.LogSuccess(AppMessages.MainMenu.Garage.InitializedSelector, this);
        }
    }
}
