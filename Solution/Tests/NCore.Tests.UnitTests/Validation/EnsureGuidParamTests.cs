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
        public void Param_IsNotEmpty_WhenEmptyGuid_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.Param(Guid.Empty, ParamName).IsNotEmpty());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsNonEmptyGuid + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void Param_IsNotEmpty_WhenNonEmptyGuid_ReturnsPassedGuid()
        {
            var guid = Guid.NewGuid();

            var returnedGuid = Ensure.Param(guid, ParamName).IsNotEmpty();

            Assert.AreEqual(guid, returnedGuid.Value);
        }
    }
}