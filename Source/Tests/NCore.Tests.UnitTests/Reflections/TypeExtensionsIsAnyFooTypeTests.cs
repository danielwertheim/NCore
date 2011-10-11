using System;
using NCore.Reflections;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Reflections
{
    [TestFixture]
    public class TypeExtensionsIsAnyFooTypeTests : UnitTestBase
    {
        [Test]
        public void IsAnyDateTimeType_WhenDateTimeType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(DateTime).IsAnyDateTimeType());
        }

        [Test]
        public void IsAnyDateTimeType_WhenNullableDateTimeType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(DateTime?).IsAnyDateTimeType());
        }

        [Test]
        public void IsAnyDateTimeType_WhenNotDateTimeType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyDateTimeType());
        }

        [Test]
        public void IsAnyBoolType_WhenBoolType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(bool).IsAnyBoolType());
        }

        [Test]
        public void IsAnyBoolType_WhenNullableBoolType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(bool?).IsAnyBoolType());
        }

        [Test]
        public void IsAnyBoolType_WhenNotBoolType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyBoolType());
        }

        [Test]
        public void IsAnyDecimalType_WhenDecimalType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(decimal).IsAnyDecimalType());
        }

        [Test]
        public void IsAnyDecimalType_WhenNullableDecimalType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(decimal?).IsAnyDecimalType());
        }

        [Test]
        public void IsAnyDecimalType_WhenNotDecimalType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyDecimalType());
        }

        [Test]
        public void IsAnySingleType_WhenSingleType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Single).IsAnySingleType());
        }

        [Test]
        public void IsAnySingleType_WhenNullableSingleType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Single?).IsAnySingleType());
        }

        [Test]
        public void IsAnySingleType_WhenNotSingleType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnySingleType());
        }

        [Test]
        public void IsAnyFloatType_WhenFloatType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(float).IsAnyFloatType());
        }

        [Test]
        public void IsAnyFloatType_WhenNullableFloatType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(float?).IsAnyFloatType());
        }

        [Test]
        public void IsAnyFloatType_WhenNotFloatType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyFloatType());
        }

        [Test]
        public void IsAnyDoubleType_WhenDoubleType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(double).IsAnyDoubleType());
        }

        [Test]
        public void IsAnyDoubleType_WhenNullableDoubleType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(double?).IsAnyDoubleType());
        }

        [Test]
        public void IsAnyDoubleType_WhenNotDoubleType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyDoubleType());
        }

        [Test]
        public void IsAnyLongType_WhenLongType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(long).IsAnyLongType());
        }

        [Test]
        public void IsAnyLongType_WhenNullableLongType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(long?).IsAnyLongType());
        }

        [Test]
        public void IsAnyLongType_WhenNotLongType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyLongType());
        }

        [Test]
        public void IsAnyGuidType_WhenGuidType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Guid).IsAnyGuidType());
        }

        [Test]
        public void IsAnyGuidType_WhenNullableGuidType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Guid?).IsAnyGuidType());
        }

        [Test]
        public void IsAnyGuidType_WhenNotGuidType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyGuidType());
        }

        [Test]
        public void IsAnyIntType_WhenIntType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(int).IsAnyIntType());
        }

        [Test]
        public void IsAnyIntType_WhenNullableIntType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(int?).IsAnyIntType());
        }

        [Test]
        public void IsAnyIntType_WhenNotIntType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(bool).IsAnyIntType());
        }

        [Test]
        public void IsAnyByteType_WhenByteType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(byte).IsAnyByteType());
        }

        [Test]
        public void IsAnyByteType_WhenNullableByteType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(byte?).IsAnyByteType());
        }

        [Test]
        public void IsAnyByteType_WhenNotByteType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyByteType());
        }

        [Test]
        public void IsAnyShortType_WhenShortType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(short).IsAnyShortType());
        }

        [Test]
        public void IsAnyShortType_WhenNullableShortType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(short?).IsAnyShortType());
        }

        [Test]
        public void IsAnyShortType_WhenNotShortType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyShortType());
        }

        [Test]
        public void IsAnyCharType_WhenCharType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(char).IsAnyCharType());
        }

        [Test]
        public void IsAnyCharType_WhenNullableCharType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(char?).IsAnyCharType());
        }

        [Test]
        public void IsAnyCharType_WhenNotCharType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyCharType());
        }

        [Test]
        public void IsAnyEnumType_WhenEnumType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(GCCollectionMode).IsAnyEnumType());
        }

        [Test]
        public void IsAnyEnumType_WhenNullableEnumType_ReturnsTrue()
        {
            Assert.IsTrue(typeof(GCCollectionMode?).IsAnyEnumType());
        }

        [Test]
        public void IsAnyEnumType_WhenNotEnumType_ReturnsFalse()
        {
            Assert.IsFalse(typeof(int).IsAnyEnumType());
        }
    }
}