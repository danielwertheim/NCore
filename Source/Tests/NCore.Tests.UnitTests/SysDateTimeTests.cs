using System;
using NUnit.Framework;

namespace NCore.Tests.UnitTests
{
    [TestFixture]
    public class SysDateTimeTests : UnitTestBase
    {
        [Test]
        public void Now_WhenFixed_ReturnsFixedValue()
        {
            var fixedValue = new DateTime(2012, 01, 02, 12, 01, 42, 999);

            Now.ValueFn = () => fixedValue;

            Assert.AreEqual(fixedValue, Now.Value);
            Assert.AreEqual(fixedValue, Now.Value);
        }

        [Test]
        public void NowUtc_WhenFixed_ReturnsFixedValue()
        {
            var fixedValue = new DateTime(2012, 01, 02, 12, 01, 42, 999);

            Now.UtcFn = () => fixedValue;

            Assert.AreEqual(fixedValue, Now.ValueUtc);
            Assert.AreEqual(fixedValue, Now.ValueUtc);
        }
    }
}