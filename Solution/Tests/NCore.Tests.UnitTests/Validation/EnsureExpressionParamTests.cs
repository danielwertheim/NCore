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
        public void Param_IsTrue_WhenFalseExpression_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.Param(() => false, ParamName).IsTrue());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsTrueFor
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void Param_IsTrue_WhenTrueExpression_ReturnsPassedValue()
        {
            var returnedValue = Ensure.Param(() => true, ParamName).IsTrue();

            Assert.AreEqual(ParamName, returnedValue.Name);
            Assert.IsTrue(returnedValue.Expression());
        }

        [Test]
        public void Param_IsFalse_WhenTrueExpression_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.Param(() => true, ParamName).IsFalse());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsFalseFor
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void Param_IsFalse_WhenFalseExpression_ReturnsPassedValue()
        {
            var returnedValue = Ensure.Param(() => false, ParamName).IsFalse();

            Assert.AreEqual(ParamName, returnedValue.Name);
            Assert.IsFalse(returnedValue.Expression());
        }
    }
}