using System.Collections.Generic;
using System.Linq;
using NCore.Collections;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Collections
{
    [TestFixture]
    public class DictionaryExtensionsTests : UnitTestBase
    {
        [Test]
        public void GetString_WhenKeyExists_ValueIsReturned()
        {
            var kvs = CreateDictionary("Value1");

            Assert.AreEqual("Value1", kvs.GetString("Key1"));
        }

        [Test]
        public void GetString_WhenKeyDoesNotExist_ReturnsDefaultValue()
        {
            var defaultValue = "my default";
            var kvs = CreateDictionary();

            Assert.AreEqual(defaultValue, kvs.GetString("Key1", defaultValue));
        }

        [Test]
        public void GetInt_WhenKeyExists_ValueIsReturned()
        {
            var kvs = CreateDictionary("1");

            Assert.AreEqual(1, kvs.GetInt("Key1"));
        }

        [Test]
        public void GetIng_WhenKeyDoesNotExist_ReturnsDefaultValue()
        {
            var defaultValue = 42;
            var kvs = CreateDictionary();

            Assert.AreEqual(defaultValue, kvs.GetInt("Key1", defaultValue));
        }

        private static Dictionary<string, string> CreateDictionary(params string[] values)
        {
            var c = 0;

            return values.ToDictionary(value => "Key" + ++c);
        }
    }
}