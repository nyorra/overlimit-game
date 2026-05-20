using OVERLIMIT.Core.Messages.Utility;
using OVERLIMIT.Utility.Logging;
using UnityEngine;

namespace OVERLIMIT.Utility.Validation
{
    /// <summary>
    /// Методы расширения для универсальной валидации компонентов Unity.
    /// Позволяет заменить ручные проверки на лаконичную цепочку вызовов.
    /// <example>
    ///
    /// Пример использования в Start:
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
        // Начинаем цепочку, запоминая 'this' (MonoBehaviour или ScriptableObject)
        public static ValidationResult BeginValidation(this Object owner)
        {
            return new ValidationResult(owner);
        }

        // Выводим ошибки в OverLogger с указанием контекста
        public static bool LogAndCheck(this ValidationResult result)
        {
            if (result.HasError)
            {
                foreach (var error in result.Errors)
                {
                    // Если в ошибке есть точка (например view.SelectedCarText), используем NestedMissing
                    string msg = error.Contains(".")
                        ? ValidationMsg.NestedMissing(error.Split('.')[0], error.Split('.')[1])
                        : ValidationMsg.Missing(error);

                    OverLogger.LogError(msg, result.Context);
                }
            }
            else
            {
                // Если ошибок нет — выводим один зеленый лог успеха для всего объекта
                // result.Context — это исходный MonoBehaviour или ScriptableObject
                string successMsg = ValidationMsg.Success(
                    result.Context != null ? result.Context.name : "Unknown"
                );
                OverLogger.LogSuccess(successMsg, result.Context);
            }
            return result.HasError;
        }
    }
}
