using UnityEngine;

namespace OVERLIMIT.Utility.Logging
{
    [CreateAssetMenu(fileName = "LogSettings", menuName = "OVERLIMIT/Log Settings")]
    public class LogSettings : ScriptableObject
    {
        // The minimum threshold for a log to be displayed in the console.
        public LogLevels MinimumLevel = LogLevels.Success;

        // Optimization toggle for standalone builds.
        public bool EnableColorsInBuild = false;
    }
}
