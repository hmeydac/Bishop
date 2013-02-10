namespace Bishop.Services.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Bishop.Model.Entities;
    using Bishop.Repositories;
    using Bishop.Tests.Scenarios.ObjectBuilders;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class FormServiceTests
    {
        [TestMethod]
        public void FormServiceGetAllShouldReturnAllForms()
        {
            // Arrange
            var expected = this.GetSampleData();
            var unitOfWork = this.SetupUnitOfWork(expected);
            var service = new FormService(unitOfWork.Object);

            // Act
            var actual = service.GetAll();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormServiceGetListShouldReturnListOfForms()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            var expectedData = this.GetSampleData().OrderBy(f => f.Title).ToArray();
            unitOfWorkMock.Setup(u => u.Query<Form>()).Returns(expectedData.AsQueryable());
            var service = new FormService(unitOfWorkMock.Object);

            // Act
            var actual = service.GetList();
            CollectionAssert.AreEqual(expectedData, actual);
        }

        [TestMethod]
        public void FormServiceGetShouldRetrieveSingleForm()
        {
            // Arrange
            var sampleData = this.GetSampleData();
            var expected = sampleData[1]; // Arbritary Value
            var unitOfWork = this.SetupUnitOfWork(sampleData);
            var service = new FormService(unitOfWork.Object);

            // Act  
            var actual = service.Get(expected.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreSame(expected, actual);
        }

        private Mock<IUnitOfWork> SetupUnitOfWork(IEnumerable<Form> data)
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            string[] includeNames = { "Topics", "Topics.Questions", "Topics.Questions.Answers" };
            unitOfWork.Setup(u => u.Query<Form>(includeNames)).Returns(data.AsQueryable());
            return unitOfWork;
        }

        private Form[] GetSampleData()
        {
            return new[]
                       {
                           new FormBuilder().WithRandomId().Build(), new FormBuilder().WithRandomId().Build(),
                           new FormBuilder().WithRandomId().Build(), new FormBuilder().WithRandomId().Build(),
                           new FormBuilder().WithRandomId().Build()
                       };
        }
    }
}
