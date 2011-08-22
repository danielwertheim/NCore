using System;

namespace NCore.Validation
{
    public class ExpressionParam
    {
        public readonly string Name;

        public readonly Func<bool> Expression;

        internal ExpressionParam(string name, Func<bool> expression)
        {
            Name = name;
            Expression = expression;
        }
    }
}