using UnityEngine;

namespace OVERLIMIT.Logging
{
    [CreateAssetMenu(fileName = "LogSettings", menuName = "Overlimit/Log Settings")]
    public class LogSettings : ScriptableObject
    {
        public LogLevel MinimumLevel = LogLevel.Success;
        public bool EnableColorsInBuild = false;
    }
}
