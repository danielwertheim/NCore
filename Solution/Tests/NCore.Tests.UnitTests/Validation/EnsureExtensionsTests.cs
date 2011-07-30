using System;
using System.Collections.ObjectModel;
using NCore.Resources;
using NCore.Validation;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Validation
{
    [TestFixture]
    public class EnsureExtensionsTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Test]
        public void EnsureIsNotEmpty_WhenEmptyGuid_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.This(Guid.Empty).IsNotEmpty(ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsNonEmptyGuid
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsNotEmpty_WhenNonEmptyGuid_ReturnsPassedGuid()
        {
            var guid = Guid.NewGuid();

            var returnedGuid = Ensure.This(guid).IsNotEmpty(ParamName);

            Assert.AreEqual(guid, returnedGuid);
        }

        [Test]
        public void EnsureHasItems_WhenEmptyCollection_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.This(new Collection<int>()).HasItems(ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsNonEmptyCollection
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureHasItems_WhenNonEmptyCollection_ReturnsPassedCollection()
        {
            var collection = new Collection<int> { 1, 2, 3 };

            var returnedCollection = Ensure.This(collection).HasItems(ParamName);

            CollectionAssert.AreEqual(collection, returnedCollection);
        }

        [Test]
        public void EnsureHasItems_WhenEmptyArray_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.This(new int[] { }).HasItems(ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsNonEmptyCollection
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureHasItems_WhenNonEmptyArray_ReturnsPassedArray()
        {
            var array = new[] { 1, 2, 3 };

            var returnedArray = Ensure.This(array).HasItems(ParamName);

            CollectionAssert.AreEqual(array, returnedArray);
        }

        [Test]
        public void EnsureNotNull_WhenRefTypeIsNull_ThrowsArgumentNullException()
        {
            object value = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Ensure.This(value).IsNotNull(ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsNotNull
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureNotNull_WhenRefTypeIsNotNull_ReturnsPassedObjectInstance()
        {
            var item = new { Value = 42 };

            var returnedItem = Ensure.This(item).IsNotNull(ParamName);

            Assert.AreEqual(item, returnedItem);
        }

        [Test]
        public void EnsureNotNull_WhenStringIsNull_ThrowsArgumentNullException()
        {
            string value = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Ensure.This(value).IsNotNull(ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsNotNull
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureNotNull_WhenStringIsNotNull_ReturnsPassedObjectInstance()
        {
            var value = string.Empty;

            var returnedValue = Ensure.This(value).IsNotNull(ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureIsGtThan_WhenIntIsEqualToLimit_ThrowsArgumentOutOfRangeException()
        {
            var value = 42;
            var limit = 42;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => Ensure.This(value).IsGtThan(limit, ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsGtThan.Inject(value, limit)
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsGtThan_WhenIntIsLowerThanLimit_ThrowsArgumentOutOfRangeException()
        {
            var value = 42;
            var limit = 43;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => Ensure.This(value).IsGtThan(limit, ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsGtThan.Inject(value, limit)
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsGtThan_WhenIntIsGreaterThan_ReturnsPassedValue()
        {
            const int value = 42;
            const int limit = 41;

            var returnedValue = Ensure.This(value).IsGtThan(limit, ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureIsGteThan_WhenIntIsLowerThanLimit_ThrowsArgumentOutOfRangeException()
        {
            var value = 41;
            var limit = 42;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => Ensure.This(value).IsGteThan(limit, ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsGteThan.Inject(value, limit)
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsGteThan_WhenIntIsEqualToLimit_ReturnsPassedValue()
        {
            const int value = 42;
            const int limit = 42;

            var returnedValue = Ensure.This(value).IsGteThan(limit, ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureIsGteThan_WhenIntIsGreaterThan_ReturnsPassedValue()
        {
            const int value = 42;
            const int limit = 41;

            var returnedValue = Ensure.This(value).IsGteThan(limit, ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureIsInRange_WhenIntIsOnLowerLimit_ReturnsPassedValue()
        {
            const int lowerLimit = 42;
            const int upperLimit = 50;
            const int value = lowerLimit;

            var returnedValue = Ensure.This(value).IsInRange(lowerLimit, upperLimit, ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureIsInRange_WhenIntIsOnUpperLimit_ReturnsPassedValue()
        {
            const int lowerLimit = 42;
            const int upperLimit = 50;
            const int value = upperLimit;

            var returnedValue = Ensure.This(value).IsInRange(lowerLimit, upperLimit, ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureIsInRange_WhenIntIsBetweenLimits_ReturnsPassedValue()
        {
            const int lowerLimit = 40;
            const int upperLimit = 50;
            const int value = 45;

            var returnedValue = Ensure.This(value).IsInRange(lowerLimit, upperLimit, ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureIsInRange_WhenIntIsLowerThanLowerLimit_ThrowsArgumentOutOfRangeException()
        {
            const int lowerLimit = 40;
            const int upperLimit = 50;
            const int value = lowerLimit - 1;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => Ensure.This(value).IsInRange(lowerLimit, upperLimit, ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsInRange_ToLow.Inject(value, lowerLimit)
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsInRange_WhenIntIsGreaterThanUpperLimit_ThrowsArgumentOutOfRangeException()
        {
            const int lowerLimit = 40;
            const int upperLimit = 50;
            const int value = upperLimit + 1;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => Ensure.This(value).IsInRange(lowerLimit, upperLimit, ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsInRange_ToHigh.Inject(value, upperLimit)
                + "\r\nParameter name: test",
                ex.Message);
        }
    }
}