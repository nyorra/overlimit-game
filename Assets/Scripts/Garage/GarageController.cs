using UnityEngine;
using UnityEngine.UI;

namespace OVERLIMIT.Garage
{
    public class GarageController : MonoBehaviour
    {
        [Header("Components")]
        public GarageUI view;
        public GarageSelector selector;

        [Header("Buttons")]
        public Button nextButton;
        public Button prevButton;

        void Start()
        {
            nextButton.onClick.AddListener(() => selector.SwitchCar(1));
            prevButton.onClick.AddListener(() => selector.SwitchCar(-1));

            // Начальное отображение
            view.UpdateUI(selector.GetCurrentCar());
        }
    }
}
