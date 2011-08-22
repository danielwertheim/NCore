using System;

namespace NCore.Validation
{
    public class ExpressionParam
    {
        public readonly string Name;

        public readonly Func<bool> Expression;

        public ExpressionParam(string name, Func<bool> expression)
        {
            Name = name;
            Expression = expression;
        }
    }
}