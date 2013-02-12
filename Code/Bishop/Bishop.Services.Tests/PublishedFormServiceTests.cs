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
    public class PublishedFormServiceTests
    {
        [TestMethod]
        public void PublishedFormServiceGetAllShouldRetrieveActiveForms()
        {
            // Arrange
            var expectedCount = 1;
            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            var publishedForm = new PublishedForm
                                    {
                                        Title = "Test",
                                        IsActive = true,
                                        FromDate = DateTime.Now,
                                        ExpirationDate = DateTime.Now.AddDays(1),
                                        Form = new FormMother().GetBasicSurvey()
                                    };

            unitOfWorkMock.Setup(u => u.Query<PublishedForm>(It.IsAny<string>())).Returns(new[] { publishedForm }.AsQueryable());
            var service = new PublishedFormService(unitOfWorkMock.Object);

            // Act
            var actual = service.GetAllActive();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedCount, actual.Count());
            Assert.AreSame(publishedForm, actual.FirstOrDefault());
        }
    }
}
