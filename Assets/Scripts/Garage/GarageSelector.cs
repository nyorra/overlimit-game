using System.Collections.Generic;
using UnityEngine;

namespace OVERLIMIT.Garage
{
    public class GarageSelector : MonoBehaviour
    {
        public List<CarData> allCars;
        private int _currentIndex;

        public static CarData SelectedCar { get; private set; }

        public void SwitchCar(int direction)
        {
            if (allCars.Count == 0) return;

            _currentIndex = (_currentIndex + direction + allCars.Count) % allCars.Count;
            SelectedCar = allCars[_currentIndex];

            // Сообщаем визуалу об изменениях (через контроллер)
            GetComponent<GarageController>().view.UpdateUI(SelectedCar);
        }

        public CarData GetCurrentCar()
        {
            if (SelectedCar == null && allCars.Count > 0)
                SelectedCar = allCars[0];
            return SelectedCar;
        }
    }
}
