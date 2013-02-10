namespace Bishop.Model.Tests
{
    using System;

    using Bishop.Model.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FillingSessionTests
    {
        [TestMethod]
        public void FillingSessionDefaultConstructorShouldWork()
        {
            // Act
            var actual = new FillingSession();
            var actualId = actual.Id;
            var actualIsActive = actual.IsActive;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(Guid.Empty, actualId);
            Assert.IsTrue(actualIsActive);
        }
    }
}
