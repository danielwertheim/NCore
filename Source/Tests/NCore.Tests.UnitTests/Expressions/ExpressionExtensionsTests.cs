using System;
using System.Linq.Expressions;
using NCore.Expressions;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Expressions
{
    [TestFixture]
    public class ExpressionExtensionsTests
    {
        [Test]
        public void GetRightMostMemberExpression_WhenStartsWithOnToStringOfNullable_ReturnsMember()
        {
            var e = CreateExpression<Dummy>(d => d.ChildItem.NullableInt.ToString().StartsWith("42"));

            var memberExpression = e.GetRightMostMember();

            Assert.AreEqual("NullableInt", memberExpression.Member.Name);
        }

        [Test]
        public void GetRightMostMemberExpression_WhenExpressionIsNotForAMember_ReturnsNull()
        {
            var e = CreateExpression<Dummy>(d => d.Firstname == "FOO".ToLower());

            var memberExpression = e.GetRightMostMember();

            Assert.IsNull(memberExpression);
        }

        [Test]
        public void ToPath_WhenPassingRootMember_ReturnsPathWithRootMemberNameAndNoDelimitors()
        {
            var memberExpression = CreateMemberExpression<Dummy>(d => d.Age);

            var path = memberExpression.ToPath();

            Assert.AreEqual("Age", path);
        }

        [Test]
        public void ToPath_WhenPassingChildMember_ReturnsPathWithParentNameDelimitorAndChildMemberName()
        {
            var memberExpression = CreateMemberExpression<Dummy>(d => d.ChildItem.ChildAge);

            var path = memberExpression.ToPath();

            Assert.AreEqual("ChildItem.ChildAge", path);
        }

        private MemberExpression CreateMemberExpression<T>(Expression<Func<T, dynamic>> e)
        {
            return (MemberExpression)(e.Body as UnaryExpression).Operand;
        }

        private Expression CreateExpression<T>(Expression<Func<T, dynamic>> e)
        {
            return e;
        }

        private class Dummy
        {
            public int Age { get; set; }
            public string Firstname { get; set; }
            public Child ChildItem { get; set; }
        }

        private class Child
        {
            public int ChildAge { get; set; }
            public int? NullableInt { get; set; }
        }
    }
}