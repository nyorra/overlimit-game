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
        public List<CarModels> allCars;
        private int _currentIndex = 0;

        private void Start()
        {
            PrevButton.onClick.AddListener(SwitchPrev);
            NextButton.onClick.AddListener(SwitchNext);

            UpdateUI();
        }

        public void SwitchPrev()
        {
            _currentIndex = (_currentIndex + 1) % allCars.Count;
            UpdateUI();
        }

        public void SwitchNext()
        {
            _currentIndex = (_currentIndex - 1 + allCars.Count) % allCars.Count;
            UpdateUI();
        }

        public void UpdateUI()
        {
            if (allCars == null || allCars.Count == 0) return; 
            CarModels currentCar = allCars[_currentIndex];
            SelectedCarText.text = currentCar.CarName;
            OverLogger.LogSuccess($"Выбрана машина: {currentCar.CarName}");
        }

    }   
}
