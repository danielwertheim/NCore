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
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_IsTrueFor);

            return param;
        }

        [DebuggerStepThrough]
        public static ExpressionParam IsFalse(this ExpressionParam param)
        {
            if (param.Expression())
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_IsFalseFor);

            return param;
        }
    }
}