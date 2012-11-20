using System;
using NCore.Cryptography;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Cryptography
{
    [TestFixture]
    public class Sha1HashServiceTests : UnitTestBase
    {
        private IHashService _hasher;

        protected override void OnFixtureInitialize()
        {
            _hasher = new Sha1HashService();
        }

        [Test]
        public void GenerateHash_WhenNullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _hasher.GenerateHash(null));
        }

        [Test]
        public void GenerateHash_EmptyString_Returns40Chars()
        {
            var value = string.Empty;

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("da39a3ee5e6b4b0d3255bfef95601890afd80709", hash);
        }

        [Test]
        public void GenerateHash_When256Chars_Returns40Chars()
        {
            var value = new string('a', 256);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("9c78512ad150c8b5d8918395ad0e5169397d2b62", hash);
        }

        [Test]
        public void GenerateHash_When512Chars_Returns40Chars()
        {
            var value = new string('a', 512);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("164557facb73929875168c1e92caf09bb6064564", hash);
        }

        [Test]
        public void GenerateHash_When1024Chars_Returns40Chars()
        {
            var value = new string('a', 1024);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("8eca554631df9ead14510e1a70ae48c70f9b9384", hash);
        }

        [Test]
        public void GenerateHash_When2048Chars_Returns40Chars()
        {
            var value = new string('a', 2048);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("dc28591e574d1eac79ad07b7a4d01d5026a02428", hash);
        }

        [Test]
        public void GenerateHash_When4096Chars_Returns40Chars()
        {
            var value = new string('a', 4096);
            
            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("8c51fb6a0b587ec95ca74acfa43df7539b486297", hash);
        }

        [Test]
        public void GenerateHash_WhenTwoIdenticalStrings_ReturnsSameHash()
        {
            var hash1 = _hasher.GenerateHash("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            var hash2 = _hasher.GenerateHash("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");

            Assert.IsNotNullOrEmpty(hash1);
            Assert.AreEqual(hash1, hash2);
        }

        [Test]
        public void GenerateHash_WhenTwoStringsDifferentInCasing_DoesNotReturnSameHash()
        {
            var hash1 = _hasher.GenerateHash("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            var hash2 = _hasher.GenerateHash("Lorem ipsum dolor sit AMET, consectetur adipiscing elit.");

            Assert.IsNotNullOrEmpty(hash1);
            Assert.IsNotNullOrEmpty(hash2);
            Assert.AreNotEqual(hash1, hash2);
        }
    }
}