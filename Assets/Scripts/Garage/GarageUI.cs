using UnityEngine;
using TMPro;

namespace OVERLIMIT.Garage
{
    public class GarageUI : MonoBehaviour // Переименовал в UI
    {
        public TMP_Text carNameText;

        public void UpdateUI(CarData car)
        {
            if (car != null)
            {
                carNameText.text = car.CarName;
            }
        }
    }
}
