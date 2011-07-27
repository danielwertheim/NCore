using NUnit.Framework;

namespace NCore.Tests.UnitTests.Reflections
{
    [TestFixture]
    public class TypeExtensionsIsNullableTypeTests : UnitTestBase
    {
        [Test]
        public void IsNullableValueType_WhenNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(int?).IsNullableValueType());
        }

        [Test]
        public void IsNullableValueType_WhenInt_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsNullableValueType());
        }

        [Test]
        public void IsNullableValueType_WhenString_ReturnsFalse()
        {
            Assert.IsFalse(typeof(string).IsNullableValueType());
        }
    }
}