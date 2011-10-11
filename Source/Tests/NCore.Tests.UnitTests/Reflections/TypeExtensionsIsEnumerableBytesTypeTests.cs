using NCore.Reflections;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Reflections
{
    [TestFixture]
    public class TypeExtensionsIsEnumerableBytesTypeTests : UnitTestBase
    {
        [Test]
        public void IsEnumerableBytesType_WhenBytesArray_ReturnsTrue()
        {
            Assert.IsTrue(typeof(byte[]).IsEnumerableBytesType());
        }

        [Test]
        public void IsEnumerableBytesType_WhenNullableBytesArray_ReturnsTrue()
        {
            Assert.IsTrue(typeof(byte?[]).IsEnumerableBytesType());
        }

        [Test]
        public void IsEnumerableBytesType_WhenIntArray_ReturnsTrue()
        {
            Assert.IsFalse(typeof(int[]).IsEnumerableBytesType());
        }

        [Test]
        public void IsEnumerableBytesType_WhenNullableIntArray_ReturnsTrue()
        {
            Assert.IsFalse(typeof(int?[]).IsEnumerableBytesType());
        }
    }
}