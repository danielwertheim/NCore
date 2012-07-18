using System;
using Moq;
using NUnit.Framework;

namespace NCore.Tests.UnitTests
{
    [TestFixture]
    public class DisposerTests : UnitTestBase
    {
        [Test]
        public void TryDispose_WhenNullReferenceIsPassed_ReturnsNull()
        {
            IDisposable disposable = null;

            var ex = Disposer.TryDispose(disposable);

            Assert.IsNull(ex);
        }

        [Test]
        public void TryDispose_WhenNoExceptionIsRaisedInDispose_ReturnsNull()
        {
            var disposableMock = new Mock<IDisposable>();

            var ex = Disposer.TryDispose(disposableMock.Object);

            Assert.IsNull(ex);
            disposableMock.Verify(m => m.Dispose(), Times.Once());
        }

        [Test]
        public void TryDispose_WhenExceptionRaisedInDispose_ReturnsException()
        {
            var exceptionToThrow = new Exception("Foo");
            var disposableFake = new Mock<IDisposable>();
            disposableFake.Setup(f => f.Dispose()).Throws(exceptionToThrow);

            var ex = Disposer.TryDispose(disposableFake.Object);

            Assert.IsNotNull(ex);
            Assert.AreSame(exceptionToThrow, ex);
        }
    }
}