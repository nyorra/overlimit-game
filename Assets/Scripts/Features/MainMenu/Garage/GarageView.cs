using OVERLIMIT.Logging;
using OVERLIMIT.Messages;
using TMPro;
using UnityEngine;

namespace OVERLIMIT.Garage
{
    public class GarageView : MonoBehaviour
    {
        public TMP_Text SelectedCarText;

        private void OnEnable()
        {
            GarageSelector.OnCarChanged += UpdateUI;
        }

        private void OnDisable()
        {
            GarageSelector.OnCarChanged -= UpdateUI;
        }

        public void UpdateUI(CarData car)
        {
            SelectedCarText.text = car.CarName;
            OverLogger.LogSuccess(AppMessages.MainMenu.Garage.Updated(car.CarName), this);
        }
    }
}
