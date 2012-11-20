using System;
using NCore.Cryptography;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Cryptography
{
    [TestFixture]
    public class Md5HashServiceTests : UnitTestBase
    {
        private IHashService _hasher;

        protected override void OnFixtureInitialize()
        {
            _hasher = new Md5HashService();
        }

        [Test]
        public void GenerateHash_WhenNullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _hasher.GenerateHash(null));
        }

        [Test]
        public void GenerateHash_EmptyString_Returns32Chars()
        {
            var value = string.Empty;

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("d41d8cd98f00b204e9800998ecf8427e", hash);
        }

        [Test]
        public void GenerateHash_When256Chars_Returns32Chars()
        {
            var value = new string('a', 256);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("81109eec5aa1a284fb5327b10e9c16b9", hash);
        }

        [Test]
        public void GenerateHash_When512Chars_Returns32Chars()
        {
            var value = new string('a', 512);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("56907396339ca2b099bd12245f936ddc", hash);
        }

        [Test]
        public void GenerateHash_When1024Chars_Returns32Chars()
        {
            var value = new string('a', 1024);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("c9a34cfc85d982698c6ac89f76071abd", hash);
        }

        [Test]
        public void GenerateHash_When2048Chars_Returns32Chars()
        {
            var value = new string('a', 2048);

            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("b7ea2d21ad2ef3e28085d30247603e0b", hash);
        }

        [Test]
        public void GenerateHash_When4096Chars_Returns32Chars()
        {
            var value = new string('a', 4096);
            
            var hash = _hasher.GenerateHash(value);

            Assert.AreEqual("21a199c53f422a380e20b162fb6ebe9c", hash);
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