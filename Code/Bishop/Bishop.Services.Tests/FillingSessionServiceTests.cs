namespace Bishop.Services.Tests
{
    using System;

    using Bishop.Model.Entities;
    using Bishop.Repositories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class FillingSessionServiceTests
    {
        [TestMethod]
        public void FillingSessionServiceStartNewSessionReturnNewSession()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            unitOfWorkMock.Setup(u => u.Add(It.IsAny<FillingSession>())).Returns((FillingSession f) =>
                {
                    f.Id = Guid.NewGuid();
                    return unitOfWorkMock.Object;
                });

            unitOfWorkMock.Setup(u => u.Commit());
            var service = new FillingSessionService(unitOfWorkMock.Object);

            // Act
            var actual = service.StartNewSession();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(FillingSession));
            Assert.AreNotEqual(Guid.Empty, actual.Id);
            unitOfWorkMock.Verify(u => u.Add(It.IsAny<FillingSession>()));
            unitOfWorkMock.Verify(u => u.Commit());
        }
    }
}
