using System;
using System.Diagnostics;
using NCore.Resources;

namespace NCore.Validation
{
    public static class EnsureExpressionExtensions
    {
        [DebuggerStepThrough]
        public static Param<T> IsTrueFor<T>(this Param<T> param, Func<T, bool> expression)
        {
            if (!expression(param.Value))
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsTrueFor, param.Name);

            return param;
        }

        [DebuggerStepThrough]
        public static Param<T> IsFalseFor<T>(this Param<T> param, Func<T, bool> expression)
        {
            if (expression(param.Value))
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsFalseFor, param.Name);

            return param;
        }
    }
}