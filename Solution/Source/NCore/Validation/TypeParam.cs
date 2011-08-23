using System;

namespace NCore.Validation
{
    public class TypeParam : Param
    {
        public readonly Type Type;

        internal TypeParam(string name, Type type)
            : base(name)
        {
            Type = type;
        }
    }
}