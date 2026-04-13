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
        // список машин
        public List<CarModels> allCars;
        
        private void Start()
        {
            // Проверка всех ссылок
            Object[] GarageElements = { SelectedCarText, PrevButton, NextButton };
            foreach (var element in GarageElements)
            {
                if (element == null)
                {
                    OverLogger.LogError("Garage UI references are missing!", this);
                    return;
                }
            }

            // Список машин не должен быть пустым
            if (allCars == null || allCars.Count == 0)
            {
                OverLogger.LogWarning("Car list is empty! Add cars to the list in Inspector.", this);
                return;
            }

            PrevButton.onClick.AddListener(SwitchPrev);
            NextButton.onClick.AddListener(SwitchNext);

            SelectCar();

            OverLogger.LogSuccess("Garage system initialized.", this);
        }

        public void SwitchPrev()
        {
            _currentIndex = (_currentIndex - 1 + allCars.Count) % allCars.Count;
            SelectCar();
        }

        public void SwitchNext()
        {
            _currentIndex = (_currentIndex + 1) % allCars.Count;
            SelectCar();
        }

        // на 0 индексе стоит дефолт первая тачка, она прогружается сразу. Потом отслеживание выбранной машины и
        // прогрузка уже ее в системе, вместо 0 индекса
        public void SelectCar()
        {
            CarModels currentCar = allCars[_currentIndex];
            
            if (currentCar == null)
            {
                OverLogger.LogError($"Car at index {_currentIndex} is null!", this);
                return;
            }

            SelectedCarText.text = currentCar.CarName;
            OverLogger.LogSuccess($"UI: Car selected -> {currentCar.CarName}", this);
        }

    }   
}
