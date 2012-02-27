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

            SysDateTime.NowFn = () => fixedValue;

            Assert.AreEqual(fixedValue, SysDateTime.Now);
            Assert.AreEqual(fixedValue, SysDateTime.Now);
        }

        [Test]
        public void NowUtc_WhenFixed_ReturnsFixedValue()
        {
            var fixedValue = new DateTime(2012, 01, 02, 12, 01, 42, 999);

            SysDateTime.NowUtcFn = () => fixedValue;

            Assert.AreEqual(fixedValue, SysDateTime.NowUtc);
            Assert.AreEqual(fixedValue, SysDateTime.NowUtc);
        }
    }
}