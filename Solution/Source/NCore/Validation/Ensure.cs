using System;

namespace NCore.Validation
{
    public static class Ensure
    {
        public static Param<T> Param<T>(T value, string name)
        {
            return new Param<T>(name, value);
        }

        public static ExpressionParam Param(Func<bool> expression, string name)
        {
            return new ExpressionParam(name, expression);
        }
    }
}