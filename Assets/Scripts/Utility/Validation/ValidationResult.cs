using System.Collections.Generic;
using UnityEngine;

namespace OVERLIMIT.Utility.Validation
{
    /// <summary>
    /// Container object that collects and stores validation results.
    /// Facilitates Fluent API check chains and preserves the source context reference for debugger routing.
    /// </summary>
    public class ValidationResult
    {
        public Object Context { get; }
        public List<string> Errors { get; } = new List<string>();
        public bool HasError => Errors.Count > 0;

        public ValidationResult(Object context) => Context = context;

        // Assures that a required reference field is assigned and not null
        public ValidationResult Require(Object component, string name)
        {
            if (component == null)
                Errors.Add(name);
            return this;
        }

        // Assures that a collection is allocated and none of its internal elements are missing or null.
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
