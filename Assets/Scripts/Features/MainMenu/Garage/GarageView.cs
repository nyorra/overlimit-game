using OVERLIMIT.Core.Messages.MainMenu;
using OVERLIMIT.Utility.Logging;
using TMPro;
using UnityEngine;

namespace OVERLIMIT.Features.MainMenu.Garage
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
            OverLogger.LogSuccess(GarageMsg.Updated(car.CarName), this);
        }
    }
}
