namespace Bishop.Services.Tests
{
    using System;
    using System.Linq;

    using Bishop.Model.Entities;
    using Bishop.Repositories;
    using Bishop.Tests.Scenarios.ObjectMothers;

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

        [TestMethod]
        public void FillingSessionServiceGetShouldReturnSession()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            var session = new FillingSessionMother().GetBasicSession();
            var sessionId = session.Id;

            unitOfWorkMock.Setup(u => u.Query<FillingSession>()).Returns(new[] { session }.AsQueryable());

            unitOfWorkMock.Setup(u => u.Commit());
            var service = new FillingSessionService(unitOfWorkMock.Object);

            // Act
            var actual = service.Get(sessionId);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(FillingSession));
            Assert.AreNotEqual(Guid.Empty, actual.Id);
            unitOfWorkMock.Verify(u => u.Query<FillingSession>());
        }
    }
}
