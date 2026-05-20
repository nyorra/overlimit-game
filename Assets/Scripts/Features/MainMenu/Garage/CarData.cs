using UnityEngine;

namespace OVERLIMIT.Features.MainMenu.Garage
{
    /// <summary>
    /// Схема данных машины
    /// </summary>
    [CreateAssetMenu(fileName = "NewCarData", menuName = "OVERLIMIT/Car Data")]
    public class CarData : ScriptableObject
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
