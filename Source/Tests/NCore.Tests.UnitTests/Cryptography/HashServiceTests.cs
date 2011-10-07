using System;
using NCore.Cryptography;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Cryptography
{
    [TestFixture]
    public class HashServiceTests : UnitTestBase
    {
        private IHashService _hasher;

        protected override void OnFixtureInitialize()
        {
            _hasher = new Crc32HashService();
        }

        [Test]
        public void GetHashLength_Returns8()
        {
            var hashLength = _hasher.GetHashLength();

            Assert.AreEqual(8, hashLength);
        }

        [Test]
        public void HashLengthComparision_WhenStringEmpty_AreEqual()
        {
            var hashLength = _hasher.GetHashLength();

            var hash = _hasher.GenerateHash(string.Empty);

            Assert.AreEqual(hashLength, hash.Length);
        }

        [Test]
        public void HashLengthComparision_WhenNotStringEmpty_AreEqual()
        {
            var hashLength = _hasher.GetHashLength();

            var hash = _hasher.GenerateHash("Some arbitrary text.");

            Assert.AreEqual(hashLength, hash.Length);
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
    }
}