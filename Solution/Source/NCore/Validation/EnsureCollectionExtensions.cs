using System;
using System.Collections;
using System.Diagnostics;
using NCore.Resources;

namespace NCore.Validation
{
    public static class EnsureCollectionExtensions
    {
        [DebuggerStepThrough]
        public static Param<T> HasItems<T>(this Param<T> param) where T : class, ICollection
        {
            if (param.Value == null || param.Value.Count < 1)
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsNonEmptyCollection, param.Name);

            return param;
        }
    }
}