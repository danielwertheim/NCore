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

        private class Dummy
        {
            public int Age { get; set; }

            public Child ChildItem { get; set; }
        }

        private class Child
        {
            public int ChildAge { get; set; }
        }
    }
}