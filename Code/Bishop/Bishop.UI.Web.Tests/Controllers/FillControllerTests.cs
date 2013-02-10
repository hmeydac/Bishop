namespace Bishop.UI.Web.Tests.Controllers
{
    using System;
    using System.Web.Mvc;

    using Bishop.Services;
    using Bishop.Tests.Scenarios.ObjectMothers;
    using Bishop.UI.Web.Controllers;

    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class FillControllerTests
    {
        private readonly IUnityContainer container = new UnityContainer();

        [TestMethod]
        public void FillControllerIndexWithIdShouldRedirectToFillingForm()
        {
            // Arrange
            var expectedAction = "Template";
            var expectedController = "Form";
            var expectedFormId = Guid.NewGuid();
            var sessionServiceMock = new FillingSessionServiceMother(this.container).GetMockedService();
            var session = new FillingSessionMother().GetBasicSession();
            var expectedSessionId = session.Id;
            sessionServiceMock.Setup(s => s.StartNewSession()).Returns(session);
            var controller = new FillController(sessionServiceMock.Object);

            // Act
            var actual = controller.Index(expectedFormId) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedAction, actual.RouteValues["action"].ToString());
            Assert.AreEqual(expectedController, actual.RouteValues["controller"].ToString());
            Assert.AreEqual(expectedFormId, actual.RouteValues["formId"]);
            Assert.AreEqual(expectedSessionId, actual.RouteValues["sid"]);
            sessionServiceMock.Verify(s => s.StartNewSession());
        }
    }
}
