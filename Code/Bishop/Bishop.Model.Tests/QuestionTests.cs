using System;
using Bishop.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bishop.Model.Tests
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void QuestionDefaultConstructorShouldWork()
        {
            // Arrage
            var expectedId = 0;
            var expectedText = string.Empty;

            // Act
            var question = new Question();

            // Assert
            Assert.IsNotNull(question);
            Assert.AreEqual(expectedId, question.Id);
            Assert.AreEqual(expectedText, question.Text);
        }
    }
}
