using System;

namespace NCore.Validation
{
    public static class Ensure
    {
        public static Param<T> Param<T>(T value, string name)
        {
            return new Param<T>(name, value);
        }

        public static ExpressionParam ParamExpression(Func<bool> expression, string name)
        {
            return new ExpressionParam(name, expression);
        }

        public static TypeParam ParamTypeFor<T>(T value, string name)
        {
            return new TypeParam(value.GetType(), name);
        }
    }
}