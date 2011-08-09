using System;
using System.Collections.ObjectModel;
using NCore.Resources;
using NCore.Validation;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Validation
{
    [TestFixture]
    public class EnsureCollectionParamsTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Test]
        public void HasItems_WhenEmptyCollection_ThrowsArgumentException()
        {
            var emptyCollection = new Collection<int>();

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.Param(emptyCollection, ParamName).HasItems());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsNonEmptyCollection
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void HasItems_WhenNonEmptyCollection_ReturnsPassedCollection()
        {
            var collection = new Collection<int> { 1, 2, 3 };

            var returnedCollection = Ensure.Param(collection, ParamName).HasItems();

            CollectionAssert.AreEqual(collection, returnedCollection.Value);
        }

        [Test]
        public void HasItems_WhenEmptyArray_ThrowsArgumentException()
        {
            var emptyArray = new int[] {};

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.Param(emptyArray, ParamName).HasItems());

            Assert.AreEqual(ParamName, ex.ParamName);
            Assert.AreEqual(ExceptionMessages.EnsureExtensions_IsNonEmptyCollection
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Test]
        public void HasItems_WhenNonEmptyArray_ReturnsPassedArray()
        {
            var array = new[] { 1, 2, 3 };

            var returnedArray = Ensure.Param(array, ParamName).HasItems();

            CollectionAssert.AreEqual(array, returnedArray.Value);
        }        
    }
}