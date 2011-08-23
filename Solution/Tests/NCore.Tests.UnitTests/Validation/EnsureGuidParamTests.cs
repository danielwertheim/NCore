using System;
using NCore.Resources;
using NCore.Validation;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Validation
{
    [TestFixture]
    public class EnsureGuidParamTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Test]
        public void IsNotEmpty_WhenEmptyGuid_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(Guid.Empty, ParamName).IsNotEmpty());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsNonEmptyGuid + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void IsNotEmpty_WhenNonEmptyGuid_ReturnsPassedGuid()
        {
            var guid = Guid.NewGuid();

            var returnedValue = Ensure.That(guid, ParamName).IsNotEmpty();

            Assert.AreEqual(ParamName, returnedValue.Name);
            Assert.AreEqual(guid, returnedValue.Value);
        }
    }
}