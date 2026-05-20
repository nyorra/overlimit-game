using OVERLIMIT.Core.Messages.MainMenu;
using OVERLIMIT.Utility.Logging;
using OVERLIMIT.Utility.Validation;
using UnityEngine;
using UnityEngine.UI;

namespace OVERLIMIT.Features.MainMenu.Garage
{
    /// <summary>
    /// Проверка модулей, инит кнопок вызов селектора - выбор машины
    /// </summary>
    public class GarageController : MonoBehaviour
    {
        public GarageSelector selector;
        public GarageView view;

        [Header("Controls")]
        public Button nextButton;
        public Button prevButton;

        void Start()
        {
            // базовая проверка модулей
            var validation = this.BeginValidation()
                .Require(selector, nameof(selector))
                .Require(view, nameof(view))
                .Require(nextButton, nameof(nextButton))
                .Require(prevButton, nameof(prevButton))
                // Обращаемся к тексту ЧЕРЕЗ объект view
                .Require(view?.SelectedCarText, $"{nameof(view)}.{nameof(view.SelectedCarText)}")
                .RequireList(selector?.allCars, $"{nameof(selector)}.{nameof(selector.allCars)}");

            if (validation.LogAndCheck())
                return;

            // проходим по всем машинам и проверяем их префабы
            foreach (var car in selector.allCars)
            {
                // Проверяем, что у каждой машины в ассете назначен префаб
                validation.Require(car.CarPrefab, $"{car.name}.{nameof(car.CarPrefab)}");
            }

            nextButton.onClick.AddListener(() => selector.SwitchCar(1));
            prevButton.onClick.AddListener(() => selector.SwitchCar(-1));

            OverLogger.LogSuccess(GarageMsg.PrevNextButton, this);
        }
    }
}
