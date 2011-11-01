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

        [Test]
        public void AppendWith_WhenStringHasValue_TextIsPrepended()
        {
            Assert.AreEqual("You did append me.", "You did".AppendWith(" append me."));
        }

        [Test]
        public void AppendWith_WhenStringIsEmpty_TextIsNotPrepended()
        {
            Assert.AreEqual(string.Empty, string.Empty.AppendWith("This should not be prepended"));
        }

        [Test]
        public void AppendWith_WhenStringIsNull_TextIsNotPrepended()
        {
            Assert.AreEqual(null, (null as string).AppendWith("This should not be prepended"));
        }

        [Test]
        public void PrependWith_WhenStringHasValue_TextIsPrepended()
        {
            Assert.AreEqual("You did Prepend me.", "Prepend me.".PrependWith("You did "));
        }

        [Test]
        public void PrependWith_WhenStringIsEmpty_TextIsNotPrepended()
        {
            Assert.AreEqual(string.Empty, string.Empty.PrependWith("This should not be prepended"));
        }

        [Test]
        public void PrependWith_WhenStringIsNull_TextIsNotPrepended()
        {
            Assert.AreEqual(null, (null as string).PrependWith("This should not be prepended"));
        }
    }
}