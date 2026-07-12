using System;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace OVERLIMIT.Utility.Logging
{
    /// <summary>
    /// Global logging system.
    /// Supports level-based filtering, rich text color formatting, and contextual object linking.
    /// </summary>
    public static class OverLogger
    {
        // Settings cache
        private static LogSettings _settings;

        // Safety flag ensuring settings are loaded only once per session.
        private static bool _settingsLoaded;

        private static LogSettings Settings
        {
            get
            {
                if (!_settingsLoaded)
                {
                    _settings = Resources.Load<LogSettings>("LogSettings");

                    // Fallback: create a temporary instance in memory if the asset is missing to prevent null exceptions.
                    if (_settings == null)
                        _settings = ScriptableObject.CreateInstance<LogSettings>();
                    _settingsLoaded = true;
                }
                return _settings;
            }
        }

        // Compares the incoming log level against the minimum threshold allowed in settings.
        private static bool IsAllowed(LogLevels level) => Settings.MinimumLevel <= level;

        //Logs a successful operation. Stripped from final release builds via [Conditional].
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        [UnityEngine.HideInCallstack]
        public static void LogSuccess(string message, Object context = null)
        {
            if (IsAllowed(LogLevels.Success))
                Debug.Log(
                    Format(LogConfig.PrefixSuccess, message, LogConfig.ColorSuccess, context),
                    context
                );
        }

        //Logs a waning notification. Stripped from final release builds via [Conditional].
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        [UnityEngine.HideInCallstack]
        public static void LogWarning(string message, Object context = null)
        {
            if (IsAllowed(LogLevels.Warning))
                Debug.LogWarning(
                    Format(LogConfig.PrefixWarning, message, LogConfig.ColorWarning, context),
                    context
                );
        }

        // Logs a critical error. Active across all build types.
        [UnityEngine.HideInCallstack]
        public static void LogError(string message, Object context = null)
        {
            if (IsAllowed(LogLevels.Error))
                Debug.LogError(
                    Format(LogConfig.PrefixError, message, LogConfig.ColorError, context),
                    context
                );
        }

        // Logs a system exception while preserving the full stack trace structure.
        [UnityEngine.HideInCallstack]
        public static void LogError(Exception ex, Object context = null)
        {
            if (!IsAllowed(LogLevels.Error) || ex == null)
                return;
            Debug.LogError(
                Format(
                    LogConfig.PrefixError,
                    $"Exception: {ex.Message}",
                    LogConfig.ColorError,
                    context
                ),
                context
            );
            Debug.LogException(ex, context);
        }

        private static string Format(string prefix, string message, string color, Object context)
        {
            message ??= "NULL";
            string finalMsg = $"{prefix} {message}";

#if UNITY_EDITOR
            return $"<color={color}>{finalMsg}</color>";
#else
            if (Settings.EnableColorsInBuild)
                return $"<color={color}>{finalMsg}</color>";
            return finalMsg;
#endif
        }
#if UNITY_EDITOR
        //Clears the Unity Editor console programmatically using reflection.
        [Conditional("UNITY_EDITOR")]
        public static void ClearConsole()
        {
            var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
            var type = assembly.GetType("UnityEditor.LogEntries");
            type.GetMethod("Clear").Invoke(new object(), null);
        }
    }
}
#endif