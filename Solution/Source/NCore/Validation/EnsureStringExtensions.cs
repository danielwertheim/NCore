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
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_HasNonWhiteSpaceValue, param.Name);

            return param;
        }
    }
}