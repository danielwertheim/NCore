using System;
using NCore.Reflections;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Reflections
{
    [TestFixture]
    public class TypeExtensionsIsNullableTypeTests : UnitTestBase
    {
        [Test]
        public void IsNullablePrimitiveType_WhenNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(int?).IsNullablePrimitiveType());
        }

        [Test]
        public void IsNullablePrimitiveType_WhenInt_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsNullablePrimitiveType());
        }

        [Test]
        public void IsNullablePrimitiveType_WhenString_ReturnsFalse()
        {
            Assert.IsFalse(typeof(string).IsNullablePrimitiveType());
        }

        [Test]
        public void IsNullableDateTimeType_WhenNullableDateTime_ReturnsTrue()
        {
            Assert.IsTrue(typeof(DateTime?).IsNullableDateTimeType());
        }

        [Test]
        public void IsNullableDateTimeType_WhenDateTime_ReturnsFalse()
        {
            Assert.IsFalse(typeof(DateTime).IsNullableDateTimeType());
        }

        [Test]
        public void IsNullableBoolType_WhenNullableBool_ReturnsTrue()
        {
            Assert.IsTrue(typeof(bool?).IsNullableBoolType());
        }

        [Test]
        public void IsNullableBoolType_WhenBool_ReturnsFalse()
        {
            Assert.IsFalse(typeof(bool).IsNullableBoolType());
        }

        [Test]
        public void IsNullableDecimalType_WhenNullableDecimal_ReturnsTrue()
        {
            Assert.IsTrue(typeof(decimal?).IsNullableDecimalType());
        }

        [Test]
        public void IsNullableDecimalType_WhenDecimal_ReturnsFalse()
        {
            Assert.IsFalse(typeof(decimal).IsNullableDecimalType());
        }

        [Test]
        public void IsNullableSingleType_WhenNullableSingle_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Single?).IsNullableSingleType());
        }

        [Test]
        public void IsNullableSingleType_WhenSingle_ReturnsFalse()
        {
            Assert.IsFalse(typeof(Single).IsNullableSingleType());
        }

        [Test]
        public void IsNullableFloatType_WhenNullableFloat_ReturnsTrue()
        {
            Assert.IsTrue(typeof(float?).IsNullableFloatType());
        }

        [Test]
        public void IsNullableFloatType_WhenFloat_ReturnsFalse()
        {
            Assert.IsFalse(typeof(float).IsNullableFloatType());
        }

        [Test]
        public void IsNullableDoubleType_WhenNullableDouble_ReturnsTrue()
        {
            Assert.IsTrue(typeof(double?).IsNullableDoubleType());
        }

        [Test]
        public void IsNullableDoubleType_WhenDouble_ReturnsFalse()
        {
            Assert.IsFalse(typeof(double).IsNullableDoubleType());
        }

        [Test]
        public void IsNullableLongType_WhenNullableLong_ReturnsTrue()
        {
            Assert.IsTrue(typeof(long?).IsNullableLongType());
        }

        [Test]
        public void IsNullableLongType_WhenLong_ReturnsFalse()
        {
            Assert.IsFalse(typeof(long).IsNullableLongType());
        }

        [Test]
        public void IsNullableGuidType_WhenNullableGuid_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Guid?).IsNullableGuidType());
        }

        [Test]
        public void IsNullableGuidType_WhenGuid_ReturnsFalse()
        {
            Assert.IsFalse(typeof(Guid).IsNullableGuidType());
        }

        [Test]
        public void IsNullableIntType_WhenNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(int?).IsNullableIntType());
        }

        [Test]
        public void IsNullableIntType_WhenInt_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsNullableIntType());
        }

        [Test]
        public void IsNullableShortType_WhenNullableShort_ReturnsTrue()
        {
            Assert.IsTrue(typeof(short?).IsNullableShortType());
        }

        [Test]
        public void IsNullableShortType_WhenShort_ReturnsFalse()
        {
            Assert.IsFalse(typeof(short).IsNullableShortType());
        }

        [Test]
        public void IsNullableCharType_WhenNullableChar_ReturnsTrue()
        {
            Assert.IsTrue(typeof(char?).IsNullableCharType());
        }

        [Test]
        public void IsNullableCharType_WhenChar_ReturnsFalse()
        {
            Assert.IsFalse(typeof(char).IsNullableCharType());
        }

        [Test]
        public void IsNullableEnumType_WhenNullableEnum_ReturnsTrue()
        {
            Assert.IsTrue(typeof(GCCollectionMode?).IsNullableEnumType());
        }

        [Test]
        public void IsNullableEnumType_WhenEnum_ReturnsFalse()
        {
            Assert.IsFalse(typeof(GCCollectionMode).IsNullableEnumType());
        }
    }
}