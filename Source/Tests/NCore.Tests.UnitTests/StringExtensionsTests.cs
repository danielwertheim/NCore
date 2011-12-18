using NUnit.Framework;

namespace NCore.Tests.UnitTests
{
    [TestFixture]
    public class StringExtensionsTests : UnitTestBase
    {
		[Test]
		public void EndsWithAny_WhenFirstArgMatchesEnding_ReturnsTrue()
		{
			Assert.IsTrue("Foo bar".EndsWithAny("bar", "car"));
		}

    	[Test]
    	public void EndsWithAny_WhenSecondArgMatchesEnding_ReturnsTrue()
    	{
    		Assert.IsTrue("Foo bar".EndsWithAny("Goo", "bar"));
    	}

		[Test]
		public void EndsWithAny_WhenNoArgMathcesEnding_ReturnsFalse()
		{
			Assert.IsFalse("Foo bar".EndsWithAny("Goo", "car"));
		}

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
        public void ToStringOrNull_WhenStringEmpty_ReturnsStringEmpty()
        {
            Assert.AreEqual(string.Empty, string.Empty.ToStringOrNull());
        }

        [Test]
        public void ToStringOrNull_WhenNull_ReturnsStringEmpty()
        {
            Assert.IsNull((null as object).ToStringOrNull());
        }

        [Test]
        public void ToStringOrNull_WhenNullInt_ReturnsStringEmpty()
        {
            int? v = null;

            Assert.AreEqual(null, v.ToStringOrNull());
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