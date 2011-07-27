using System;
using NUnit.Framework;

namespace NCore.Tests.UnitTests
{
    [TestFixture]
    public class StringConverterTests : UnitTestBase
    {
        private readonly IStringConverter _stringConverter = new StringConverter(Sys.Formatting);

        [Test]
        public void AsString_ForInt_ReturnsIntAsString()
        {
            Assert.AreEqual("1", _stringConverter.AsString(1));
        }

        [Test]
        public void AsString_ForFloatWithFractals_ReturnsAsStringWithCorrectDelimAndFractals()
        {
            Assert.AreEqual("4.345", _stringConverter.AsString((float)4.345));
        }

        [Test]
        public void AsString_ForDoubleWithFractals_ReturnsAsStringWithCorrectDelimAndFractals()
        {
            Assert.AreEqual("4.345", _stringConverter.AsString(4.345));
        }

        [Test]
        public void AsString_ForDecimalWithFractals_ReturnsAsStringWithCorrectDelimAndFractals()
        {
            Assert.AreEqual("4.345", _stringConverter.AsString(4.345M));
        }

        [Test]
        public void AsString_ForDateTime_ReturnsDateTimeInFormat_yyyy_mm_dd_mm_ss_ff()
        {
            Assert.AreEqual("2010-01-02 03:04:05.006", _stringConverter.AsString(new DateTime(2010, 1, 2, 3, 4, 5, 6)));
        }

        [Test]
        public void AsString_ForTrueBool_Returns_True()
        {
            Assert.AreEqual("True", _stringConverter.AsString(true));
        }

        [Test]
        public void AsString_ForFalseBool_Returns_False()
        {
            Assert.AreEqual("False", _stringConverter.AsString(false));
        }

        [Test]
        public void AsString_WhenGuid_ReturnsGuidString()
        {
            const string guidString = "4126c8c3-66d2-44d2-932b-93563628eea3";

            Assert.AreEqual(guidString, _stringConverter.AsString(Guid.Parse(guidString)));
        }

        [Test]
        public void AsString_WhenString_ReturnsTheString()
        {
            Assert.AreEqual("Test", _stringConverter.AsString("Test"));
        }

        [Test]
        public void AsString_WhenNullString_ReturnsNull()
        {
            Assert.IsNull(_stringConverter.AsString<string>(null));
        }

        [Test]
        public void AsString_WhenEmptyGuid_ReturnsEmptyGuidString()
        {
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", _stringConverter.AsString(Guid.Empty));
        }

        [Test]
        public void AsString_WhenDbNull_ReturnsNull()
        {
            Assert.IsNull(_stringConverter.AsString(DBNull.Value));
        }
    }
}