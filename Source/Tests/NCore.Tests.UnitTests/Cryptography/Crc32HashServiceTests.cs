using System;
using NCore.Cryptography;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Cryptography
{
    [TestFixture]
    public class Crc32HashServiceTests : UnitTestBase
    {
        private IHashService _hasher;

        protected override void OnFixtureInitialize()
        {
            _hasher = new Crc32HashService();
        }

        [Test]
        public void GenerateHash_WhenNullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _hasher.GenerateHash(null));
        }

        [Test]
        public void GenerateHash_EmptyString_Returns8Zeros()
        {
            var value = string.Empty;

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("00000000", hash);
        }

        [Test]
        public void GenerateHash_When256Chars_Returns8Chars()
        {
            var value = new string('a', 256);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("b07d3659", hash);
        }

        [Test]
        public void GenerateHash_When512Chars_Returns8Chars()
        {
            var value = new string('a', 512);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("f9517051", hash);
        }

        [Test]
        public void GenerateHash_When1024Chars_Returns8Chars()
        {
            var value = new string('a', 1024);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("7c5597b9", hash);
        }

        [Test]
        public void GenerateHash_When2048Chars_Returns8Chars()
        {
            var value = new string('a', 2048);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("443d72ec", hash);
        }

        [Test]
        public void GenerateHash_When4096Chars_Returns8Chars()
        {
            var value = new string('a', 4096);
            
            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("9c99dc73", hash);
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