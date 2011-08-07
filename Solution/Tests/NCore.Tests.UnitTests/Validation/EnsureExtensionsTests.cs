using System;
using System.Collections.ObjectModel;
using NCore.Resources;
using NCore.Validation;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Validation
{
    [TestFixture]
    public class EnsureGuidExtensionsTests : UnitTestBase
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
    }

    [TestFixture]
    public class EnsureStringExtensionsTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Test]
        public void EnsureIsNotNull_WhenStringIsNull_ThrowsArgumentNullException()
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
        public void EnsureIsNotNull_WhenStringIsNotNull_ReturnsPassedString()
        {
            var value = string.Empty;

            var returnedValue = Ensure.This(value).IsNotNull(ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureHasNonWhiteSpaceValue_WhenWhiteSpaceString_ThrowsArgumentNullException()
        {
            string value = " ";

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.This(value).HasNonWhiteSpaceValue(ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_HasNonWhiteSpaceValue
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureHasNonWhiteSpaceValue_WhenStringHasValue_ReturnsPassedString()
        {
            var value = "delta";

            var returnedValue = Ensure.This(value).HasNonWhiteSpaceValue(ParamName);

            Assert.AreEqual(value, returnedValue);
        }
    }

    [TestFixture]
    public class EnsureNumericExtensionsTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Test]
        public void EnsureIsGtThan_WhenIntIsEqualToLimit_ThrowsArgumentOutOfRangeException()
        {
            var limit = 42;
            var value = 42;

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
            var limit = 43;
            var value = 42;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => Ensure.This(value).IsGtThan(limit, ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsGtThan.Inject(value, limit)
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsGtThan_WhenIntIsGreaterThanLimit_ReturnsPassedValue()
        {
            const int limit = 41;
            const int value = 42;

            var returnedValue = Ensure.This(value).IsGtThan(limit, ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureIsGteThan_WhenIntIsEqualToLimit_ReturnsPassedValue()
        {
            const int limit = 42;
            const int value = 42;

            var returnedValue = Ensure.This(value).IsGteThan(limit, ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureIsGteThan_WhenIntIsLowerThanLimit_ThrowsArgumentOutOfRangeException()
        {
            var limit = 42;
            var value = 41;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => Ensure.This(value).IsGteThan(limit, ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsGteThan.Inject(value, limit)
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsGteThan_WhenIntIsGreaterThan_ReturnsPassedValue()
        {
            const int limit = 41;
            const int value = 42;

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

    [TestFixture]
    public class EnsureCollectionExtensionsTests : UnitTestBase
    {
        private const string ParamName = "test";

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
    }

    [TestFixture]
    public class EnsureObjectExtensionsTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Test]
        public void EnsureIsNotNull_WhenRefTypeIsNull_ThrowsArgumentNullException()
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
        public void EnsureIsNotNull_WhenRefTypeIsNotNull_ReturnsPassedObjectInstance()
        {
            var item = new { Value = 42 };

            var returnedItem = Ensure.This(item).IsNotNull(ParamName);

            Assert.AreEqual(item, returnedItem);
        }        
    }

    [TestFixture]
    public class EnsureExpressionExtensionsTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Test]
        public void EnsureIsTrueFor_WhenFalseExpression_ThrowsArgumentException()
        {
            int value = 42;
            Func<int, bool> expression = 
                v => 1 != 1;

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.This(expression).IsTrueFor(value, ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsTrueFor
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsTrueFor_WhenTrueExpression_ReturnsPassedValue()
        {
            int value = 42;
            Func<int, bool> expression =
                v => 1 == 1;

            var returnedValue = Ensure.This(expression).IsTrueFor(value, ParamName);

            Assert.AreEqual(value, returnedValue);
        }

        [Test]
        public void EnsureIsFalseFor_WhenTrueExpression_ThrowsArgumentException()
        {
            int value = 42;
            Func<int, bool> expression =
                v => 1 == 1;

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.This(expression).IsFalseFor(value, ParamName));

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(
                ExceptionMessages.EnsureExtensions_IsFalseFor
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void EnsureIsFalseFor_WhenFalseExpression_ReturnsPassedValue()
        {
            int value = 42;
            Func<int, bool> expression =
                v => 1 != 1;

            var returnedValue = Ensure.This(expression).IsFalseFor(value, ParamName);

            Assert.AreEqual(value, returnedValue);
        }
    }
}