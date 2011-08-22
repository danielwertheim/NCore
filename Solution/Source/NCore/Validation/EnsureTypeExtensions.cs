using System;
using System.Diagnostics;
using NCore.Resources;

namespace NCore.Validation
{
    public static class EnsureTypeExtensions
    {
        [DebuggerStepThrough]
        public static TypeParam IsOfType(this TypeParam param, Type type)
        {
            if (!param.Type.Equals(type))
                throw new ArgumentException(
                    ExceptionMessages.EnsureExtensions_IsOfType.Inject(param.Type.FullName), 
                    param.Name);

            return param;
        }
    }
}