using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OVERLIMIT.Logging;

namespace OVERLIMIT.Garage
{
    public class Garage : MonoBehaviour
    {
        [Header("UI элементы")]
        public TMP_Text SelectedCarText;
        public Button PrevButton;
        public Button NextButton;

        [Header("Данные автомобилей")]
        public int _currentIndex;
        public List<CarModels> allCars;

        private void Start()
        {
            // Проверка всех ссылок на UI
            Object[] GarageElements = { SelectedCarText, PrevButton, NextButton };
            foreach (var element in GarageElements)
            {
                if (element == null)
                {
                    OverLogger.LogError($"Критическая ошибка: В инспекторе Garage не назначены ссылка на {element} UI!", this);
                    return;
                }
            }

            CarModels.AllCarsRegistry = allCars;

            // Проверка списка машин
            if (allCars == null || allCars.Count == 0)
            {
                OverLogger.LogWarning("Предупреждение: Список машин пуст! Добавьте машины в инспекторе.", this);
                return;
            }

            PrevButton.onClick.AddListener(SwitchPrev);
            NextButton.onClick.AddListener(SwitchNext);

            SelectCar();

            OverLogger.LogSuccess("Система Гаража успешно инициализирована.", this);
        }

        public void SwitchPrev()
        {
            // Листаем назад (индекс вниз)
            _currentIndex = (_currentIndex - 1 + allCars.Count) % allCars.Count;
            SelectCar();
        }

        public void SwitchNext()
        {
            // Листаем вперед (индекс вверх)
            _currentIndex = (_currentIndex + 1) % allCars.Count;
            SelectCar();
        }

        public void SelectCar()
        {
            if (allCars == null || allCars.Count == 0) return;

            CarModels currentCar = allCars[_currentIndex];

            if (currentCar == null)
            {
                OverLogger.LogError($"Ошибка: Машина под индексом {_currentIndex} не найдена (null)!", this);
                return;
            }

            SelectedCarText.text = currentCar.CarName;
            CarModels.SelectedCarName = currentCar.CarName;

            // Логируем выбор конкретной модели
            OverLogger.LogSuccess($"Гараж: Выбран автомобиль [{currentCar.CarName}].", this);
        }
    }
}
