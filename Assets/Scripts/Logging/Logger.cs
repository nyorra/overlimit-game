using UnityEngine;
using static OVERLIMIT.Logging.LogConfig;

namespace OVERLIMIT.Logging
{
    public class OverLogger
    {
        public static void LogSuccess(string MessageSuccess) 
        {
            Debug.Log($"<color={ColorSuccess}>{PrefixSuccess} {MessageSuccess}</color>");
        }

        public static void LogWarning(string ConditionValue)
        {
            Debug.LogWarning($"<color={ColorWarning}>{PrefixWarning} {ConditionValue}</color>");

        }

        public static void LogError(string Exception)
        {
            Debug.LogError($"<color={ColorError}>{PrefixError} {Exception}</color>");

        }

    }
}