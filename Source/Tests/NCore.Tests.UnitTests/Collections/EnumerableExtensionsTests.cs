using System;
using NCore.Collections;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Collections
{
    [TestFixture]
    public class EnumerableExtensionsTests : UnitTestBase
    {
        [Test]
        public void TryForAll_WhenTwoActionsThrowsExceptions_TheTwoExceptionsAreReturned()
        {
            var strings = new[] { "A", "B" };

            var caught = strings.TryForAll(s =>
            {
                throw new Exception(s);
            });

            Assert.AreEqual(strings[0], caught[0].Message);
            Assert.AreEqual(strings[1], caught[1].Message);
        }

        [Test]
        public void TryForAll_WhenNoActionThrowsAnyException_NullIsReturned()
        {
            var strings = new[] { "A", "B" };

            var caught = strings.TryForAll(s => {});

            Assert.IsNull(caught);
        }
    }
}