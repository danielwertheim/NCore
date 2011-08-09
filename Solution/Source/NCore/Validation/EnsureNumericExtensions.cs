using System;
using System.Diagnostics;
using NCore.Resources;

namespace NCore.Validation
{
    public static class EnsureNumericExtensions
    {
        [DebuggerStepThrough]
        public static Param<int> IsGtThan(this Param<int> param, int limit)
        {
            if (param.Value <= limit)
                throw new ArgumentOutOfRangeException(param.Name, ExceptionMessages.EnsureExtensions_IsGtThan.Inject(param.Value, limit));

            return param;
        }

        [DebuggerStepThrough]
        public static Param<int> IsGteThan(this Param<int> param, int limit)
        {
            if (!(param.Value >= limit))
                throw new ArgumentOutOfRangeException(param.Name, ExceptionMessages.EnsureExtensions_IsGteThan.Inject(param.Value, limit));

            return param;
        }

        [DebuggerStepThrough]
        public static Param<int> IsInRange(this Param<int> param, int min, int max)
        {
            if (param.Value < min)
                throw new ArgumentOutOfRangeException(param.Name, ExceptionMessages.EnsureExtensions_IsInRange_ToLow.Inject(param.Value, min));

            if (param.Value > max)
                throw new ArgumentOutOfRangeException(param.Name, ExceptionMessages.EnsureExtensions_IsInRange_ToHigh.Inject(param.Value, max));

            return param;
        }
    }
}