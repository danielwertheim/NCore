using System.Diagnostics;
using NCore.Resources;

namespace NCore.Validation
{
    public static class EnsureBoolExtensions
    {
        [DebuggerStepThrough]
        public static Param<bool> IsTrue(this Param<bool> param)
        {
            if (!param.Value)
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_IsTrueFor);

            return param;
        }

        [DebuggerStepThrough]
        public static Param<bool> IsFalse(this Param<bool> param)
        {
            if (param.Value)
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_IsFalseFor);

            return param;
        }
    }
}