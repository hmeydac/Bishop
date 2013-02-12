namespace Bishop.UI.Web.Tests.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Bishop.Model.Entities;
    using Bishop.Services;
    using Bishop.Tests.Scenarios.ObjectMothers;
    using Bishop.UI.Web.Controllers;
    using Bishop.UI.Web.Models.Forms;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Answer = Bishop.Model.Entities.Answer;
    using Question = Bishop.Model.Entities.Question;
    using Topic = Bishop.Model.Entities.Topic;

    [TestClass]
    public class HomeControllerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            // Create Maps for Model and ViewModel
            Mapper.CreateMap<Form, Models.Forms.UserForm>();
            Mapper.CreateMap<Topic, Models.Forms.Topic>();
            Mapper.CreateMap<Question, Models.Forms.Question>();
            Mapper.CreateMap<Answer, Models.Forms.Answer>();
        }

        [TestMethod]
        public void IndexActionShouldReturnListOfTemplates()
        {
            // Arrange
            var template = new FormMother().GetBasicSurvey();
            var formServiceMock = new Mock<IFormService>(MockBehavior.Strict);
            formServiceMock.Setup(f => f.GetList()).Returns(new[] { template });
            var controller = new HomeController(formServiceMock.Object);

            // Act
            var actual = controller.Index() as ViewResult;
            var actualViewModel = actual.Model;

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actualViewModel);
            Assert.IsInstanceOfType(actualViewModel, typeof(IEnumerable<UserForm>));
            Assert.IsTrue(((IEnumerable<UserForm>)actualViewModel).Count() == 1);
        }
    }
}
