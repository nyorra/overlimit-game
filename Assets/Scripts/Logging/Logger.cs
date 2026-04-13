using UnityEngine;
using static OVERLIMIT.Logging.LogConfig;

namespace OVERLIMIT.Logging
{
    public class OverLogger
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            // Подписываемся на все логи Unity
            Application.logMessageReceived += HandleUnityLogs;
        }

        private static void HandleUnityLogs(string logString, string stackTrace, LogType type)
        {
            // Ловим только exceptions и обычные Error
            if (type == LogType.Exception || type == LogType.Error)
            {
                LogError($"{logString} \n {stackTrace}");
            }
        }

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