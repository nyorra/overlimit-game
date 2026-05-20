using UnityEngine;

namespace OVERLIMIT.Utility.Logging
{
    [CreateAssetMenu(fileName = "LogSettings", menuName = "OVERLIMIT/Log Settings")]
    public class LogSettings : ScriptableObject
    {
        // Минимальный уовень отображения логов в консоли
        public LogLevels MinimumLevel = LogLevels.Success;

        // Оптимизация при сборке
        public bool EnableColorsInBuild = false;
    }
}
