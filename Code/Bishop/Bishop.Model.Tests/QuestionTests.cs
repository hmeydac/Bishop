﻿namespace Bishop.Model.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bishop.Framework.Exceptions;
    using Bishop.Model.Entities;
    using Bishop.Model.Tests.ObjectMother;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void QuestionDefaultConstructorShouldWork()
        {
            // Arrage
            var expectedId = 0;
            var expectedAnswersCount = 0;
            var expectedText = string.Empty;
            var expectedType = QuestionTypes.SingleOption;

            // Act
            var actual = new Question();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Answers);
            Assert.IsInstanceOfType(actual.Answers, typeof(IEnumerable<Answer>));
            Assert.AreEqual(expectedAnswersCount, actual.Answers.Count());
            Assert.AreEqual(expectedType, actual.QuestionType);
            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(expectedText, actual.Text);
        }

        [TestMethod]
        public void QuestionIdShouldGetAndSetValues()
        {
            // Arrange
            var question = new QuestionObjectMother().Build();
            var expected = 45;

            // Act
            question.Id = expected;
            var actual = question.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuestionTextShouldGetAndSetValues()
        {
            // Arrange
            var question = new QuestionObjectMother().Build();
            var expected = "Test Question";

            // Act
            question.Text = expected;
            var actual = question.Text;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuestionTypeShouldGetAndSetValues()
        {
            // Arrange
            var question = new QuestionObjectMother().Build();
            var expected = QuestionTypes.SingleOption;

            // Act
            question.QuestionType = expected;
            var actual = question.QuestionType;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddAnswerToQuestionShouldWork()
        {
            // Arrange
            var expectedAnswerTitle = "Test Answer";
            var expectedCount = 1;
            var question = new QuestionObjectMother().Build();
            var answer = new AnswerObjectMother().WithText(expectedAnswerTitle).Build();

            // Act
            question.AddAnswer(answer);
            var actualCount = question.Answers.Count();
            var actualAnswer = question.Answers.FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreSame(answer, actualAnswer);
        }

        [TestMethod]
        public void RemoveAnswerToQuestionShouldWork()
        {
            // Arrange
            var expectedCount = 0;
            var answer = new AnswerObjectMother().Build();
            var question = new QuestionObjectMother().WithAnswer(answer).Build();

            // Act
            question.RemoveAnswer(answer);
            var actualCount = question.Answers.Count();
            var actualAnswer = question.Answers.FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreSame(null, actualAnswer);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void RemoveInexistentAnswerShouldFail()
        {
            // Arrange
            var expectedCount = 1;
            var falseAnswer = new AnswerObjectMother().Build();
            var answer = new AnswerObjectMother().Build();
            var question = new QuestionObjectMother().WithAnswer(answer).Build();

            // Act
            question.RemoveAnswer(falseAnswer);
        }
    }
}
