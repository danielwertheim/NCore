using System;
using NCore.Resources;
using NCore.Validation;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Validation
{
    [TestFixture]
    public class EnsureObjectParamTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Test]
        public void IsNotNull_WhenRefTypeIsNull_ThrowsArgumentNullException()
        {
            object value = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Ensure.That(value, ParamName).IsNotNull());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsNotNull
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void IsNotNull_WhenRefTypeIsNotNull_ReturnsPassedObjectInstance()
        {
            var item = new { Value = 42 };

            var returnedItem = Ensure.That(item, ParamName).IsNotNull();

            Assert.AreEqual(ParamName, returnedItem.Name);
            Assert.AreEqual(item, returnedItem.Value);
        }        
    }
}