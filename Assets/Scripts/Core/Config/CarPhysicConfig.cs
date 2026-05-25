using UnityEngine;

namespace OVERLIMIT.Core.Config
{
    [CreateAssetMenu(fileName = "NewCarPhysicConfig", menuName = "OVERLIMIT/Car Physic Config")]
    public class CarPhysicConfig : ScriptableObject
    {
        [Header("Параметры физики подвески машин")]
        public float suspensionRestLength = 0.7f;
        public float springStrength = 250f;
        public float springDamper = 25f;

        [Header("Friction & Grip")]
        public float tireGripFactor = 10f; // Боковое трение (сцепление)
        public float engineForce = 35f; // Тяга мотора
    }
}
