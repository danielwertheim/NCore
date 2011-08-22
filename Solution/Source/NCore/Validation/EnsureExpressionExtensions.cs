using System;
using System.Diagnostics;
using NCore.Resources;

namespace NCore.Validation
{
    public static class EnsureExpressionExtensions
    {
        [DebuggerStepThrough]
        public static ExpressionParam IsTrue(this ExpressionParam param)
        {
            if (!param.Expression())
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsTrueFor, param.Name);

            return param;
        }

        [DebuggerStepThrough]
        public static ExpressionParam IsFalse(this ExpressionParam param)
        {
            if (param.Expression())
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsFalseFor, param.Name);

            return param;
        }
    }
}