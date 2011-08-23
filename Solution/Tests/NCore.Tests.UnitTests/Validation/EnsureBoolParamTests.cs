﻿using System;
using NCore.Resources;
using NCore.Validation;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Validation
{
    [TestFixture]
    public class EnsureBoolParamTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Test]
        public void IsTrue_WhenFalseExpression_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(false, ParamName).IsTrue());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsTrueFor
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void IsTrue_WhenTrueExpression_ReturnsPassedValue()
        {
            var returnedValue = Ensure.That(true, ParamName).IsTrue();

            Assert.AreEqual(ParamName, returnedValue.Name);
            Assert.IsTrue(returnedValue.Value);
        }

        [Test]
        public void IsFalse_WhenTrueExpression_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(true, ParamName).IsFalse());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsFalseFor
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void IsFalse_WhenFalseExpression_ReturnsPassedValue()
        {
            var returnedValue = Ensure.That(false, ParamName).IsFalse();

            Assert.AreEqual(ParamName, returnedValue.Name);
            Assert.IsFalse(returnedValue.Value);
        }
    }
}