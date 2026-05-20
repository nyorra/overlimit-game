using OVERLIMIT.Core.Messages.City;
using OVERLIMIT.Features.MainMenu.Garage;
using OVERLIMIT.Utility.Logging;
using UnityEngine;

namespace OVERLIMIT.Features.City.Car
{
    public class CarSpawner : MonoBehaviour
    {
        void Start()
        {
            if (GarageSelector.SelectedCar == null)
            {
                OverLogger.LogError(SelfCityMsg.SelectNull, this);
            }
        }
    }
}
