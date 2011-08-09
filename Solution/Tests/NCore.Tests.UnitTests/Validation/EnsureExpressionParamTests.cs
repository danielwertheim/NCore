using System;
using NCore.Resources;
using NCore.Validation;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Validation
{
    [TestFixture]
    public class EnsureExpressionParamTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Test]
        public void EnsureIsTrueFor_WhenFalseExpression_ThrowsArgumentException()
        {
            var value = 42;
            Func<int, bool> falseExpression = v => false;

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.Param(value, ParamName).IsTrueFor(falseExpression));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsTrueFor
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsTrueFor_WhenTrueExpression_ReturnsPassedValue()
        {
            var value = 42;
            Func<int, bool> trueExpression = v => true;

            var returnedValue = Ensure.Param(value, ParamName).IsTrueFor(trueExpression);

            Assert.AreEqual(value, returnedValue.Value);
        }

        [Test]
        public void EnsureIsFalseFor_WhenTrueExpression_ThrowsArgumentException()
        {
            var value = 42;
            Func<int, bool> trueExpression = v => true;

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.Param(value, ParamName).IsFalseFor(trueExpression));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsFalseFor
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsFalseFor_WhenFalseExpression_ReturnsPassedValue()
        {
            var value = 42;
            Func<int, bool> falseExpression = v => false;

            var returnedValue = Ensure.Param(value, ParamName).IsFalseFor(falseExpression);

            Assert.AreEqual(value, returnedValue.Value);
        }
    }
}