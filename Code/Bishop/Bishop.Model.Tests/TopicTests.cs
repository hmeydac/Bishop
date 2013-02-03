namespace Bishop.Model.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bishop.Framework.Exceptions;
    using Bishop.Model.Entities;
    using Bishop.Tests.ObjectMothers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TopicTests
    {
        [TestMethod]
        public void TopicDefaultConstructorShouldWork()
        {
            // Arrange
            var expectedTitle = string.Empty;
            var expectedId = 0;
            var expectedQuestionsCount = 0;

            // Act
            var actual = new Topic();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Questions);
            Assert.IsInstanceOfType(actual.Questions, typeof(List<Question>));
            Assert.AreEqual(expectedQuestionsCount, actual.Questions.Count());
            Assert.AreEqual(expectedTitle, actual.Title);
            Assert.AreEqual(expectedId, actual.Id);
        }

        [TestMethod]
        public void TopicIdShouldGetAndSetValues()
        {
            // Arrange
            var topic = new TopicObjectMother().Build();
            var expected = 45;

            // Act
            topic.Id = expected;
            var actual = topic.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TopicTitleShouldGetAndSetValues()
        {
            // Arrange
            var topic = new TopicObjectMother().Build();
            var expected = "Test Topic";

            // Act
            topic.Title = expected;
            var actual = topic.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddQuestionToTopicShouldWork()
        {
            // Arrange
            var expectedQuestionTitle = "Test Question";
            var expectedCount = 1;
            var topic = new TopicObjectMother().Build();
            var question = new QuestionObjectMother().WithText(expectedQuestionTitle).Build();

            // Act
            topic.Questions.Add(question);
            var actualCount = topic.Questions.Count();
            var actualQuestion = topic.Questions.FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreSame(question, actualQuestion);
        }

        [TestMethod]
        public void RemoveQuestionToTopicShouldWork()
        {
            // Arrange
            var expectedCount = 0;
            var question = new QuestionObjectMother().Build();
            var topic = new TopicObjectMother().WithQuestion(question).Build();

            // Act
            topic.Questions.Remove(question);
            var actualCount = topic.Questions.Count();
            var actualQuestion = topic.Questions.FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreSame(null, actualQuestion);
        }

        [TestMethod]
        public void RemoveInexistentQuestionShouldFail()
        {
            // Arrange
            var expectedCount = 1;
            var falseQuestion = new QuestionObjectMother().Build();
            var question = new QuestionObjectMother().Build();
            var topic = new TopicObjectMother().WithQuestion(question).Build();

            // Act
           var actual = topic.Questions.Remove(falseQuestion);
            
            // Assert
            Assert.IsFalse(actual);
        }
    }
}
