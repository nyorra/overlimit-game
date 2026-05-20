using UnityEngine;

namespace OVERLIMIT.Core.Config
{
    [CreateAssetMenu(fileName = "NewCarConfig", menuName = "OVERLIMIT/Car Config")]
    public class CarConfig : ScriptableObject
    {
        [Header("Параметры машины")]
        private float motorForce = 10000f; // Мощность
        private float brakeForce = 10000f; // Тормоза
    }
}
