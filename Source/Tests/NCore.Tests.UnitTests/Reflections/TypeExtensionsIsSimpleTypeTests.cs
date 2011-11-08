using System;
using System.Collections;
using System.Collections.Generic;
using NCore.Reflections;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Reflections
{
    [TestFixture]
    public class TypeExtensionsIsSimpleTypeTests : UnitTestBase
    {
        [Test]
        public void IsSimpleType_WhenKeyValuePair_ReturnsTrue()
        {
            Assert.IsFalse(typeof(KeyValuePair<int, int>).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenKeyValuePairDefinition_ReturnsTrue()
        {
            Assert.IsFalse(typeof(KeyValuePair<,>).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenClass_ReturnsFalse()
        {
            Assert.IsFalse(typeof(DummyClass).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(int).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenByte_ReturnsTrue()
        {
            Assert.IsTrue(typeof(byte).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenDecimal_ReturnsTrue()
        {
            Assert.IsTrue(typeof(decimal).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenDateTime_ReturnsTrue()
        {
            Assert.IsTrue(typeof(DateTime).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenString_ReturnsTrue()
        {
            Assert.IsTrue(typeof(string).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenBool_ReturnsTrue()
        {
            Assert.IsTrue(typeof(bool).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenDouble_ReturnsTrue()
        {
            Assert.IsTrue(typeof(double).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenFloat_ReturnsTrue()
        {
            Assert.IsTrue(typeof(float).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenGuid_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Guid).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenEnum_ReturnsTrue()
        {
            Assert.IsTrue(typeof(DummyEnum).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenIEnumerable_ReturnsFalse()
        {
            Assert.IsFalse(typeof(IEnumerable).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(int?).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenNullableLong_ReturnsTrue()
        {
            Assert.IsTrue(typeof(long?).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenNullableDecimal_ReturnsTrue()
        {
            Assert.IsTrue(typeof(decimal?).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenNullableDouble_ReturnsTrue()
        {
            Assert.IsTrue(typeof(double?).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenNullableSingle_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Single?).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenNullableFloat_ReturnsTrue()
        {
            Assert.IsTrue(typeof(float?).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenNullableByte_ReturnsTrue()
        {
            Assert.IsTrue(typeof(byte?).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenNullableDateTime_ReturnsTrue()
        {
            Assert.IsTrue(typeof(DateTime?).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenNullableBool_ReturnsTrue()
        {
            Assert.IsTrue(typeof(bool?).IsSimpleType());
        }

        [Test]
        public void IsSimpleType_WhenNullableGuid_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Guid?).IsSimpleType());
        }

        private enum DummyEnum
        {
        }

        private class DummyClass
        {
        }
    }
}