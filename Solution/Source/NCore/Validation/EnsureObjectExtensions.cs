using System;
using System.Diagnostics;
using NCore.Resources;

namespace NCore.Validation
{
    public static class EnsureObjectExtensions
    {
        [DebuggerStepThrough]
        public static Param<T> IsNotNull<T>(this Param<T> param) where T : class
        {
            if (param.Value == null)
                throw new ArgumentNullException(param.Name, ExceptionMessages.EnsureExtensions_IsNotNull);

            return param;
        }
    }
}