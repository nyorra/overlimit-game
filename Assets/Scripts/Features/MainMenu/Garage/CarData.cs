using UnityEngine;

namespace OVERLIMIT.Features.MainMenu.Garage
{
    /// <summary>
    /// Configuration schema for vehicle assets, defining model references and physics attributes.
    /// </summary>
    [CreateAssetMenu(fileName = "NewCarData", menuName = "OVERLIMIT/Car Data")]
    public class CarData : ScriptableObject
    {
        [Header("Identity & Visuals")]
        public string CarName;
        public GameObject CarPrefab;
        public GameObject WheelPrefab;

        [Header("Mechanical Specs")]
        public float MaxSpeed;
        public float Torque;
        public float BrakeForce;
    }
}
