using System.Collections.Generic;
using System.Collections.ObjectModel;
using NCore.Reflections;
using NCore.Resources;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Reflections
{
    [TestFixture]
    public class TypeExtensionsGetEnumerableElementTypeTests : UnitTestBase
    {
        [Test]
        public void GetEnumerableElementType_WhenIEnumerableOfT_ReturnsElementType()
        {
            var elementType = typeof(IEnumerable<DummyClass>).GetEnumerableElementType();

            Assert.AreEqual(typeof(DummyClass), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenICollectionOfT_ReturnsElementType()
        {
            var elementType = typeof(ICollection<DummyClass>).GetEnumerableElementType();

            Assert.AreEqual(typeof(DummyClass), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenCollectionOfT_ReturnsElementType()
        {
            var elementType = typeof(Collection<DummyClass>).GetEnumerableElementType();

            Assert.AreEqual(typeof(DummyClass), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenIListOfT_ReturnsElementType()
        {
            var elementType = typeof(IList<DummyClass>).GetEnumerableElementType();

            Assert.AreEqual(typeof(DummyClass), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenListOfT_ReturnsElementType()
        {
            var elementType = typeof(List<DummyClass>).GetEnumerableElementType();

            Assert.AreEqual(typeof(DummyClass), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenISetOfT_ReturnsElementType()
        {
            var elementType = typeof(ISet<DummyClass>).GetEnumerableElementType();

            Assert.AreEqual(typeof(DummyClass), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenHashSetOfT_ReturnsElementType()
        {
            var elementType = typeof(HashSet<DummyClass>).GetEnumerableElementType();

            Assert.AreEqual(typeof(DummyClass), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenIntArray_ReturnsElementType()
        {
            var elementType = typeof(int[]).GetEnumerableElementType();

            Assert.AreEqual(typeof(int), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenNullableIntArray_ReturnsElementType()
        {
            var elementType = typeof(int?[]).GetEnumerableElementType();

            Assert.AreEqual(typeof(int?), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenStringArray_ReturnsElementType()
        {
            var elementType = typeof(string[]).GetEnumerableElementType();

            Assert.AreEqual(typeof(string), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenCustomList_ReturnsElementType()
        {
            var elementType = typeof(IValidCustomList<int>).GetEnumerableElementType();

            Assert.AreEqual(typeof(int), elementType);
        }

        [Test]
        public void GetEnumerableElementType_WhenMoreThanOneGenericArg_ThrowsPineConeException()
        {
            var ex = Assert.Throws<NCoreException>(() => typeof(IInvalidCustomList<int, string>).GetEnumerableElementType());

            Assert.AreEqual(ExceptionMessages.TypeExtensions_ExtractGenericType, ex.Message);
        }

        private class DummyClass
        {
        }

        private interface IValidCustomList<out T1> : IEnumerable<T1>
        { }

        private interface IInvalidCustomList<out T1, T2> : IEnumerable<T1>
        { }
    }
}