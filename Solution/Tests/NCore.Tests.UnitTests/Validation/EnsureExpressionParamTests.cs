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
        public void EnsureIsTrue_WhenFalseExpression_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.Param(() => false, ParamName).IsTrue());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsTrueFor
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsTrue_WhenTrueExpression_ReturnsPassedValue()
        {
            var returnedValue = Ensure.Param(() => true, ParamName).IsTrue();

            Assert.IsTrue(returnedValue.Expression());
        }

        [Test]
        public void EnsureIsFalseFor_WhenTrueExpression_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.Param(() => true, ParamName).IsFalse());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsFalseFor
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsFalseFor_WhenFalseExpression_ReturnsPassedValue()
        {
            var returnedValue = Ensure.Param(() => false, ParamName).IsFalse();

            Assert.IsFalse(returnedValue.Expression());
        }
    }
}