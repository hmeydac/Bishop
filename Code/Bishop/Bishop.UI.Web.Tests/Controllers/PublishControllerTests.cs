namespace Bishop.UI.Web.Tests.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Bishop.Model.Entities;
    using Bishop.Services;
    using Bishop.Tests.Scenarios.ObjectMothers;
    using Bishop.UI.Web.Models.Forms;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class PublishControllerTests
    {
        private MockRepository mockRepository;

        [TestInitialize]
        public void Initialize()
        {
            this.mockRepository  = new MockRepository(MockBehavior.Strict);
            Mapper.CreateMap<PublishedForm, PublicationViewModel>();
        }

        [TestMethod]
        public void PublishControllerIndexActionShouldReturnForms()
        {
            // Arrange
            var publishedFormServiceMock = this.mockRepository.Create<IPublishedFormService>();
            var expectedForms = new PublishedFormMother().GetArrayPublishedForm();
            publishedFormServiceMock.Setup(p => p.GetAllActive()).Returns(expectedForms);
            var controller = new PublishController(publishedFormServiceMock.Object);

            // Act
            var actual = controller.Index() as ViewResult;
            var actualViewModel = actual.Model;

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actualViewModel);
            Assert.IsInstanceOfType(actualViewModel, typeof(PublicationViewModel[]));
            this.mockRepository.VerifyAll();
        }
    }
}
