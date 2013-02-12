namespace Bishop.Model.Tests
{
    using System;

    using Bishop.Model.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PublishedFormTests
    {
        [TestMethod]
        public void PublishedFormDefaultConstructorShouldWork()
        {
            // Arrage
            var currentTime = DateTime.Now;
            var expectedId = Guid.Empty;
            
            // Act
            var actual = new PublishedForm();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.FromDate);
            Assert.IsTrue(DateTime.Compare(currentTime, actual.FromDate) >= 0);
            Assert.IsNull(actual.ExpirationDate);
            Assert.IsNull(actual.Form);
            Assert.AreEqual(expectedId, actual.Id);
        }
    }
}
