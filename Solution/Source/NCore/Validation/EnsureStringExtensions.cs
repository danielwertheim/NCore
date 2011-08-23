using System;
using System.Diagnostics;
using NCore.Resources;

namespace NCore.Validation
{
    public static class EnsureStringExtensions
    {
        [DebuggerStepThrough]
        public static Param<string> HasNonWhiteSpaceValue(this Param<string> param)
        {
            if (string.IsNullOrWhiteSpace(param.Value))
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_HasNonWhiteSpaceValue);

            return param;
        }
    }
}