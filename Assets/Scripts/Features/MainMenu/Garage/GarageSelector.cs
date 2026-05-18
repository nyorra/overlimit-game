using System;
using System.Collections.Generic;
using OVERLIMIT.Logging;
using OVERLIMIT.Messages;
using UnityEngine;

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
            if (allCars.Count == 0)
                return;

            // способ прокрутки машин по кругу, с помощью %
            _currentIndex = (_currentIndex + direction + allCars.Count) % allCars.Count;
            // подгружаем префаб по индексу из CarData
            SelectedCar = allCars[_currentIndex];

            OverLogger.LogSuccess(AppMessages.MainMenu.Garage.Switched(SelectedCar.CarName), this);
            OnCarChanged?.Invoke(SelectedCar);
        }
    }
}
