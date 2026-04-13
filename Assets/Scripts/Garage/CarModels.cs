using UnityEngine;

namespace OVERLIMIT.Garage
{
    [System.Serializable] // чтобы юнити видела этот класс в инспекторе
    public class CarModels
    {
        [Header("Model")]
        public string CarName;
        public GameObject CarPrefab;

        [Header("Physics")]
        public float MaxSpeed;
        public float Torque;
        public float BrakeForce;
    }
}
