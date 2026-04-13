using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OVERLIMIT.Logging;

namespace OVERLIMIT.Garage
{
    public class Garage : MonoBehaviour
    {
        [Header("UI")]
        public TMP_Text SelectedCarText;
        public Button PrevButton;
        public Button NextButton;

        [Header("Data")]
        public int _currentIndex;
        public List<CarModels> allCars;
        
        private void Start()
        {
            PrevButton.onClick.AddListener(SwitchPrev);
            NextButton.onClick.AddListener(SwitchNext);

            SelectCar();

            OverLogger.LogSuccess("Garage start прогружен");
        }

        public void SwitchPrev()
        {
            _currentIndex = (_currentIndex + 1) % allCars.Count;
            SelectCar();
        }

        public void SwitchNext()
        {
            _currentIndex = (_currentIndex - 1 + allCars.Count) % allCars.Count;
            SelectCar();
        }

        // на 0 индексе стоит дефолт первая тачка, она прогружается сразу. Потом отслеживание выбранной машины и
        // прогрузка уже ее в системе, вместо 0 индекса
        public void SelectCar()
        {
            if (allCars == null || allCars.Count == 0) return; 
            CarModels currentCar = allCars[_currentIndex];
            SelectedCarText.text = currentCar.CarName;
            OverLogger.LogSuccess($"Выбрана машина: {currentCar.CarName}");
        }

    }   
}
