using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NCore.Reflections;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Reflections
{
    [TestFixture]
    public class TypeExtensionsIsEnumerableTypeTests : UnitTestBase
    {
        [Test]
        public void IsEnumerableType_WhenISetOfT_ReturnsTrue()
        {
            Assert.IsTrue(typeof(ISet<DummyClass>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenHashSetOfT_ReturnsTrue()
        {
            Assert.IsTrue(typeof(HashSet<DummyClass>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenICollectionOfT_ReturnsTrue()
        {
            Assert.IsTrue(typeof(ICollection<DummyClass>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenCollectionOfT_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Collection<DummyClass>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenIEnumerableOfT_ReturnsTrue()
        {
            Assert.IsTrue(typeof(IEnumerable<DummyClass>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenIListOfT_ReturnsTrue()
        {
            Assert.IsTrue(typeof(IList<DummyClass>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenListOfT_ReturnsTrue()
        {
            Assert.IsTrue(typeof(List<DummyClass>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenIEnumerableOfInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(IEnumerable<int>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenIEnumearbleOfNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(IEnumerable<int?>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenIListOfInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(IList<int>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenIListOfNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(IList<int?>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenListOfInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(List<int>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenListOfNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(List<int?>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenISetOfInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(ISet<int>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenISetOfNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(ISet<int?>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenHashSetOfInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(HashSet<int>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenHashSetOfNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(HashSet<int?>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenICollectionOfInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(ICollection<int>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenICollectionOfNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(ICollection<int?>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenCollectionOfInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Collection<int>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenCollectionOfNullableInt_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Collection<int?>).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenIntArray_ReturnsTrue()
        {
            Assert.IsTrue(typeof(int[]).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenNullableIntArray_ReturnsTrue()
        {
            Assert.IsTrue(typeof(int?[]).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenStringArray_ReturnsTrue()
        {
            Assert.IsTrue(typeof(string[]).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenIEnumerable_ReturnsTrue()
        {
            Assert.IsTrue(typeof(IEnumerable).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenIList_ReturnsTrue()
        {
            Assert.IsTrue(typeof(IList).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenICollection_ReturnsTrue()
        {
            Assert.IsTrue(typeof(ICollection).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenArray_ReturnsTrue()
        {
            Assert.IsTrue(typeof(Array).IsEnumerableType());
        }

        [Test]
        public void IsEnumerableType_WhenIDictionary_ReturnsFalse()
        {
            Assert.IsFalse(typeof(IDictionary).IsEnumerableType());
        }

        private class DummyClass
        {
        }
    }
}