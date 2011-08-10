using NUnit.Framework;

namespace NCore.Tests.UnitTests
{
    [TestFixture]
    public class StringExtensionsTests : UnitTestBase
    {
        [Test]
        public void ToKeyValues_WhenTwoKeyValuePairsExists_TwoKeyValueEntriesAreCreated()
        {
            var stringValue = "Key1=Value1;Key2=Value2";

            var keyValues = stringValue.ToKeyValues(';', '=');

            Assert.AreEqual(2, keyValues.Count);
            Assert.AreEqual(keyValues["Key1"], "Value1");
            Assert.AreEqual(keyValues["Key2"], "Value2");
        }

        [Test]
        public void ToKeyValues_WhenTwoKeyValuePairsExistsWithTrailingPairDelimitor_TwoKeyValueEntriesAreCreated()
        {
            var stringValue = "Key1=Value1;Key2=Value2;";

            var keyValues = stringValue.ToKeyValues(';', '=');

            Assert.AreEqual(2, keyValues.Count);
            Assert.AreEqual(keyValues["Key1"], "Value1");
            Assert.AreEqual(keyValues["Key2"], "Value2");
        }
    }
}