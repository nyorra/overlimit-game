using OVERLIMIT.Core.Messages.MainMenu;
using OVERLIMIT.Utility.Logging;
using TMPro;
using UnityEngine;

namespace OVERLIMIT.Features.MainMenu.Garage
{
    /// <summary>
    /// Handles the visual representation of the garage UI, observing selection updates.
    /// </summary>
    public class GarageView : MonoBehaviour
    {
        [Header("UI Components")]
        public TMP_Text SelectedCarText;

        private void OnEnable()
        {
            GarageSelector.OnCarChanged += UpdateUI;
        }

        private void OnDisable()
        {
            GarageSelector.OnCarChanged -= UpdateUI;
        }

        /// Refreshes the on-screen text components with the newly selected vehicle metadata.
        public void UpdateUI(CarData car)
        {
            SelectedCarText.text = car.CarName;
            OverLogger.LogSuccess(GarageMsg.Updated(car.CarName), this);
        }
    }
}
