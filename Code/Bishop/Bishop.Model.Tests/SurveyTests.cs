namespace Bishop.Model.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bishop.Framework.Exceptions;
    using Bishop.Model.Entities;
    using Bishop.Model.Tests.ObjectMother;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SurveyTests
    {
        [TestMethod]
        public void SurveyDefaultConstructorShouldWork()
        {
            // Arrange
            var expectedId = 0;
            var expectedTopics = 0;
            var expectedTitle = string.Empty;

            // Act
            var survey = new Survey();
            var actualId = survey.Id;
            var actualTitle = survey.Title;

            // Assert
            Assert.IsNotNull(survey);
            Assert.IsNotNull(survey.Topics);
            Assert.IsInstanceOfType(survey.Topics, typeof(List<Topic>));
            Assert.AreEqual(expectedTopics, survey.Topics.Count());
            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void SurveyIdShouldGetAndSetValues()
        { 
            // Arrange
            var survey = new SurveyObjectMother().Build();
            var expected = 45;

            // Act
            survey.Id = expected;
            var actual = survey.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SurveyTitleShouldGetAndSetValues()
        {
            // Arrange
            var survey = new SurveyObjectMother().Build();
            var expected = "Test Survey";

            // Act
            survey.Title = expected;
            var actual = survey.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTopicToSurveyShouldWork()
        {
            // Arrange
            var expectedTopicTitle = "Test Topic";
            var expectedCount = 1;
            var survey = new SurveyObjectMother().Build();
            var topic = new TopicObjectMother().WithTitle(expectedTopicTitle).Build();
            
            // Act
            survey.AddTopic(topic);
            var actualCount = survey.Topics.Count();
            var actualTopic = survey.Topics.FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreSame(topic, actualTopic);            
        }

        [TestMethod]
        public void RemoveTopicToSurveyShouldWork()
        {
            // Arrange
            var expectedCount = 0;
            var topic = new TopicObjectMother().Build();
            var survey = new SurveyObjectMother().WithTopic(topic).Build();

            // Act
            survey.RemoveTopic(topic);
            var actualCount = survey.Topics.Count();
            var actualTopic = survey.Topics.FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreSame(null, actualTopic);            
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void RemoveInexistentTopicShouldFail()
        {
            // Arrange
            var expectedCount = 1;
            var falseTopic = new TopicObjectMother().Build();
            var topic = new TopicObjectMother().Build();
            var survey = new SurveyObjectMother().WithTopic(topic).Build();

            // Act
            try
            {
                survey.RemoveTopic(falseTopic);
            }
            catch (Exception)
            {
                // Assert
                Assert.AreEqual(expectedCount, survey.Topics.Count());
                Assert.AreSame(topic, survey.Topics.FirstOrDefault());
                throw;
            }

            Assert.Fail();
        }
    }
}
