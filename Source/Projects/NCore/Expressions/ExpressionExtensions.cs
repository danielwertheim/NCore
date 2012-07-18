using System;
using System.Linq.Expressions;

namespace NCore.Expressions
{
    public static class ExpressionExtensions
    {
        public static bool IsNullConstant(this ConstantExpression e)
        {
            return e.Value == null || DBNull.Value.Equals(e.Value);
        }

        public static MemberExpression GetRightMostMember(this Expression e)
        {
			if (e is LambdaExpression)
				return GetRightMostMember(((LambdaExpression)e).Body);

			if (e is MemberExpression)
				return (MemberExpression)e;

			if (e is MethodCallExpression)
			{
				var callExpression = (MethodCallExpression)e;

				if (callExpression.Object is MethodCallExpression || callExpression.Object is MemberExpression)
					return GetRightMostMember(callExpression.Object);

				var member = callExpression.Arguments.Count > 0 ? callExpression.Arguments[0] : callExpression.Object;
				return GetRightMostMember(member);
			}

			if (e is UnaryExpression)
			{
				var unaryExpression = (UnaryExpression)e;
				return GetRightMostMember(unaryExpression.Operand);
			}

            return null;
        }

        public static string ToPath(this MemberExpression e)
        {
            var path = "";
            var parent = e.Expression as MemberExpression;

            if (parent != null)
                path = parent.ToPath() + ".";

            return path + e.Member.Name;
        }
    }
}