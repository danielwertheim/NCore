using System;

namespace NCore.Validation
{
    public class TypeParam
    {
        public readonly string Name;

        public readonly Type Type;

        internal TypeParam(Type type, string name)
        {
            Name = name;
            Type = type;
        }
    }
}