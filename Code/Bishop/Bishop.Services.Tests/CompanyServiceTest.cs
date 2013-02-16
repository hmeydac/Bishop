namespace Bishop.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bishop.Model.Entities;
    using Bishop.Repositories;
    using Bishop.Tests.Scenarios.ObjectBuilders;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CompanyServiceTest
    {
        [TestMethod]
        public void CompanyServiceGetAllShouldReturnAllForms()
        {
            // Arrange
            var expected = this.GetSampleData();
            var unitOfWork = new Mock<IUnitOfWork>();
            string[] includeNames = { "Contacts" };
            unitOfWork.Setup(u => u.Query<Company>(includeNames)).Returns(expected.AsQueryable());
            var service = new CompanyService(unitOfWork.Object);

            // Act
            var actual = service.GetAll();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompanyServiceGetListShouldReturnListOfCompanies()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            var expectedData = this.GetSampleData().OrderBy(f => f.Name).ToArray();
            unitOfWorkMock.Setup(u => u.Query<Company>(It.IsAny<string>())).Returns(expectedData.AsQueryable());
            var service = new CompanyService(unitOfWorkMock.Object);

            // Act
            var actual = service.GetAll();
            CollectionAssert.AreEqual(expectedData, actual);
        }

        [TestMethod]
        public void CompanyServiceGetShouldRetrieveSingleCompany()
        {
            // Arrange
            var sampleData = this.GetSampleData();
            Company expected = sampleData[1]; // Arbritary Value
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.Query<Company>()).Returns(sampleData.AsQueryable());
            var service = new CompanyService(unitOfWork.Object);

            // Act  
            var actual = service.Get(expected.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreSame(expected, actual);
        }

        private Company[] GetSampleData()
        {
            return new[]
                       {
                           new CompanyBuilder().WithRandomId().Build(), new CompanyBuilder().WithRandomId().Build(),
                           new CompanyBuilder().WithRandomId().Build(), new CompanyBuilder().WithRandomId().Build(),
                           new CompanyBuilder().WithRandomId().Build()
                       };
        }
    }
}
