using System.Collections.Generic;
using UnityEngine;

namespace OVERLIMIT.Validate
{
    /// <summary>
    /// Объект-контейнер для сбора и хранения результатов валидации.
    /// Позволяет выстраивать цепочки проверок (Fluent API) и хранит ссылку на контекст для логирования.
    /// </summary>
    public class ValidationResult
    {
        public Object Context { get; }
        public List<string> Errors { get; } = new List<string>();
        public bool HasError => Errors.Count > 0;

        public ValidationResult(Object context) => Context = context;

        public ValidationResult Require(Object component, string name)
        {
            if (component == null)
                Errors.Add(name);
            return this;
        }

        public ValidationResult RequireList<T>(IEnumerable<T> collection, string name)
            where T : Object
        {
            if (collection == null)
            {
                Errors.Add(name);
                return this;
            }

            int index = 0;
            foreach (var item in collection)
            {
                if (item == null)
                    Errors.Add($"{name}[{index}]");
                index++;
            }
            return this;
        }
    }
}
