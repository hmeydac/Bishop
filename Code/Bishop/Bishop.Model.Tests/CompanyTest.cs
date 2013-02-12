namespace Bishop.Model.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bishop.Model.Entities;
    using Bishop.Tests.Scenarios.ObjectBuilders;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CompanyTest
    {
        [TestMethod]
        public void CompanyDefaultConstructorShouldWork()
        {
            // Arrange
            var expectedId = Guid.Empty;
            var expectedTopics = 0;
            var expectedTitle = string.Empty;

            // Act
            var company = new Company();
            var actualId = company.Id;
            var actualTitle = company.Name;

            // Assert
            Assert.IsNotNull(company);
            Assert.IsNotNull(company.Contacts);
            Assert.IsInstanceOfType(company.Contacts, typeof(List<Contact>));
            Assert.AreEqual(expectedTopics, company.Contacts.Count());
            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}
