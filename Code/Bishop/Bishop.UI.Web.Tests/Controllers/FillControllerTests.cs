namespace Bishop.UI.Web.Tests.Controllers
{
    using System;
    using System.Web.Mvc;

    using Bishop.Tests.Scenarios.ObjectMothers;
    using Bishop.UI.Web.Controllers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FillControllerTests
    {
        [TestMethod]
        public void FillControllerIndexWithIdShouldRedirectToFillingForm()
        {
            // Arrange
            var expectedAction = "Template";
            var expectedController = "Form";
            var expectedFormId = Guid.NewGuid();
            
            // Setup Mock Session Service
            var sessionServiceMock = new FillingSessionServiceMother().GetMockedService();
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

        [TestMethod]
        public void FillControllerIndexWithoutIdShouldRedirectToHome()
        {
            // Arrange
            var expectedAction = "Index";
            var expectedController = "Home";

            // Setup Mock Session Service
            var sessionServiceMock = new FillingSessionServiceMother().GetMockedService();
            var controller = new FillController(sessionServiceMock.Object);

            // Act
            var actual = controller.Index(null) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedAction, actual.RouteValues["action"].ToString());
            Assert.AreEqual(expectedController, actual.RouteValues["controller"].ToString());
        }
    }
}
