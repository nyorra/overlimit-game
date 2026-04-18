using UnityEngine;
using OVERLIMIT.Logging;
using OVERLIMIT.Garage;
using OVERLIMIT.Messages;

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