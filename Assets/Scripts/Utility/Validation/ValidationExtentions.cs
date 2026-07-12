using OVERLIMIT.Core.Messages.Utility;
using OVERLIMIT.Utility.Logging;
using UnityEngine;

namespace OVERLIMIT.Utility.Validation
{
    /// <summary>
    /// Extension methods for universal Unity component validation.
    /// Replaces repetitive manual null-checks with a clean, concise fluent chain.
    /// <example>
    /// Usage example in Start/Awake:
    /// <code>
    /// if (this.BeginValidation()
    ///     .Require(selector, nameof(selector))
    ///     .Require(view?.SelectedCarText, $"{nameof(view)}.{nameof(view.SelectedCarText)}")
    ///     .LogAndCheck()) return;
    /// </code>
    /// </example>
    /// </summary>
    public static class ValidationExtensions
    {
        /// Starts the validation chain, caching the context owner (MonoBehaviour or ScriptableObject).
        public static ValidationResult BeginValidation(this Object owner)
        {
            return new ValidationResult(owner);
        }

        // Outputs collected validation faults to OverLogger with context links, or logs a success report.
        // Return True if any dependencies are missing; otherwise, false.
        public static bool LogAndCheck(this ValidationResult result)
        {
            if (result.HasError)
            {
                foreach (var error in result.Errors)
                {
                    // If the path contains a dot (e.g., view.SelectedCarText), use NestedMissing localization format
                    string msg = error.Contains(".")
                        ? ValidationMsg.NestedMissing(error.Split('.')[0], error.Split('.')[1])
                        : ValidationMsg.Missing(error);

                    OverLogger.LogError(msg, result.Context);
                }
            }
            else
            {
                // If the check passes completely, logs a single green success message for the entire object
                string successMsg = ValidationMsg.Success(
                    result.Context != null ? result.Context.name : "Unknown"
                );
                OverLogger.LogSuccess(successMsg, result.Context);
            }
            return result.HasError;
        }
    }
}
