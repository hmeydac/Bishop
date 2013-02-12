namespace Bishop.UI.Web.Tests
{
    using System.Web.Mvc;

    using Bishop.Framework;
    using Bishop.UI.Web.App_Start;

    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DependencyInjectionConfigTests
    {
        [TestMethod]
        public void DependencyInjectionConfigWhenRegisterResolverShouldWork()
        {
            // Arrange
            var container = new UnityContainer();
            var previous = DependencyResolver.Current;

            // Act
            DependencyInjectionConfig.RegisterDependencyResolver(container);
            var actual = DependencyResolver.Current;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreNotEqual(previous, actual);
            Assert.IsInstanceOfType(actual, typeof(UnityDependencyResolver));
        }
    }
}
