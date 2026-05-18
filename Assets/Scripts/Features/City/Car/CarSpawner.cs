using OVERLIMIT.Garage;
using OVERLIMIT.Logging;
using OVERLIMIT.Messages;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    void Start()
    {
        if (GarageSelector.SelectedCar == null)
        {
            OverLogger.LogError(AppMessages.City.SelectNull, this);
        }
    }
}
