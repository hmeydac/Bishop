namespace Bishop.Model.Tests
{
    using Bishop.Model.Entities;
    using Bishop.Tests.ObjectMothers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AnswerTests
    {
        [TestMethod]
        public void AnswerDefaultConstructorShouldWork()
        {
            // Arrage
            var expectedId = 0;
            var expectedWeight = 0.0;
            var expectedText = string.Empty;

            // Act
            var actual = new Answer();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedWeight, actual.Weight);
            Assert.AreEqual(false, actual.IsCorrectAnswer);
            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(expectedText, actual.Text);
        }

        [TestMethod]
        public void AnswerIdShouldGetAndSetValues()
        {
            // Arrange
            var answer = new AnswerObjectMother().Build();
            var expected = 45;

            // Act
            answer.Id = expected;
            var actual = answer.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnswerTextShouldGetAndSetValues()
        {
            // Arrange
            var answer = new AnswerObjectMother().Build();
            var expected = "Test Answer";

            // Act
            answer.Text = expected;
            var actual = answer.Text;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnswerWeightShouldGetAndSetValues()
        {
            // Arrange
            var answer = new AnswerObjectMother().Build();
            var expected = 5;

            // Act
            answer.Weight = expected;
            var actual = answer.Weight;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnswerIsCorrectShouldGetAndSetValues()
        {
            // Arrange
            var answer = new AnswerObjectMother().Build();

            // Act
            answer.IsCorrectAnswer = true;
            var actual = answer.IsCorrectAnswer;

            // Assert
            Assert.AreEqual(true, actual);
        }
    }
}
