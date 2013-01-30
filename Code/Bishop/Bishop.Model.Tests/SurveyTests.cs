using System;
using System.Collections.Generic;
using System.Linq;
using Bishop.Model.Entities;
using Bishop.Model.Tests.ObjectMother;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bishop.Model.Tests
{
    [TestClass]
    public class SurveyTests
    {
        [TestMethod]
        public void SurveyDefaultConstructorShouldWork()
        {
            // Arrange
            var expectedId = 0;
            var expectedQuestions = 0;
            var expectedTitle = string.Empty;

            // Act
            var survey = new Survey();
            var actualId = survey.Id;
            var actualTitle = survey.Title;

            // Assert
            Assert.IsNotNull(survey);
            Assert.IsNotNull(survey.Questions);
            Assert.IsInstanceOfType(survey.Questions, typeof(IEnumerable<Question>));
            Assert.AreEqual(expectedQuestions, survey.Questions.Count());
            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void SurveyIdShouldGetAndSetValues()
        { 
            // Arrange
            var survey = new SurveyObjectMother().Get();
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
            var survey = new SurveyObjectMother().Get();
            var expected = "Test Survey";

            // Act
            survey.Title = expected;
            var actual = survey.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddQuestionToSurveyShouldWork()
        {
            // Arrange
            var expectedQuestionText = "Test Question";
            var expectedCount = 1;
            var survey = new SurveyObjectMother().Get();
            var question = new QuestionObjectMother().WithText(expectedQuestionText).Get();
            
            // Act
            survey.AddQuestion(question);
            var actualCount = survey.Questions.Count();
            var actualQuestion = survey.Questions.FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreSame(question, actualQuestion);            
        }
    }
}
