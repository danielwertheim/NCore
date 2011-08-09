using System;
using System.Diagnostics;
using NCore.Resources;

namespace NCore.Validation
{
    public static class EnsureGuidExtensions
    {
        [DebuggerStepThrough]
        public static Param<Guid> IsNotEmpty(this Param<Guid> param)
        {
            if (Guid.Empty.Equals(param.Value))
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsNonEmptyGuid, param.Name);

            return param;
        }
    }
}