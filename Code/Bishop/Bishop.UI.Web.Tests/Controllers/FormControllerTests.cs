namespace Bishop.UI.Web.Tests.Controllers
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using Bishop.Framework;
    using Bishop.Model.Entities;
    using Bishop.Services;
    using Bishop.Tests.Scenarios.ObjectMothers;
    using Bishop.UI.Web.Controllers;
    using Bishop.UI.Web.Models.Forms;

    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Answer = Bishop.Model.Entities.Answer;
    using Question = Bishop.Model.Entities.Question;
    using Topic = Bishop.Model.Entities.Topic;

    [TestClass]
    public class FormControllerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            DependencyLocator.Locator = new Locator(new UnityContainer());

            // Create Maps for Model and ViewModel
            Mapper.CreateMap<Form, Models.Forms.UserForm>();
            Mapper.CreateMap<Topic, Models.Forms.Topic>();
            Mapper.CreateMap<Question, Models.Forms.Question>();
            Mapper.CreateMap<Answer, Models.Forms.Answer>();
        }

        [TestMethod]
        public void FormControllerIndexActionRedirectsToHome()
        {
            // Arrange
            var expectedAction = "Index";
            var expectedController = "Home";
            var expectedFormId = Guid.NewGuid();
            var formServiceMock = new Mock<IFormService>(MockBehavior.Strict);
            var controller = new FormController();

            // Act
            var actual = controller.Index() as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedAction, actual.RouteValues["action"].ToString());
            Assert.AreEqual(expectedController, actual.RouteValues["controller"].ToString());
        }

        [TestMethod]
        public void FormControllerTemplateShouldReturnFormViewModel()
        {
            // Arrange
            var expectedSessionId = Guid.NewGuid();
            var session = new FillingSessionMother().GetBasicSession();
            var sessionId = session.Id;
            var template = new FormMother().GetBasicSurvey();
            var templateId = template.Id;

            // Setup Mock FormService
            var formServiceMock = new Mock<IFormService>(MockBehavior.Strict);
            formServiceMock.Setup(s => s.Get(templateId)).Returns(template);
            DependencyLocator.Locator.RegisterInstance(formServiceMock.Object);

            // Setup Mock FillingSessionService
            var fillingSessionServiceMock = new Mock<IFillingSessionService>(MockBehavior.Strict);
            fillingSessionServiceMock.Setup(s => s.Get(sessionId)).Returns(session);
            DependencyLocator.Locator.RegisterInstance(fillingSessionServiceMock.Object);

            var controller = new FormController();

            // Act
            var actual = controller.Template(templateId, sessionId) as ViewResult;
            var actualViewModel = actual.Model;
            
            // Assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actualViewModel);
            Assert.IsInstanceOfType(actualViewModel, typeof(UserForm));
            formServiceMock.Verify(s => s.Get(templateId));
            fillingSessionServiceMock.Verify(s => s.Get(sessionId));
        }
    }
}
