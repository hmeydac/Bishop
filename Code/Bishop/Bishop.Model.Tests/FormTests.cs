﻿namespace Bishop.Model.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bishop.Model.Entities;
    using Bishop.Tests.Scenarios.ObjectBuilders;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FormTests
    {
        [TestMethod]
        public void FormDefaultConstructorShouldWork()
        {
            // Arrange
            var expectedId = Guid.Empty;
            var expectedTopics = 0;
            var expectedTitle = string.Empty;

            // Act
            var form = new Form();
            var actualId = form.Id;
            var actualTitle = form.Title;

            // Assert
            Assert.IsNotNull(form);
            Assert.IsNotNull(form.Topics);
            Assert.IsInstanceOfType(form.Topics, typeof(List<Topic>));
            Assert.AreEqual(expectedTopics, form.Topics.Count());
            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void FormIdShouldGetAndSetValues()
        {
            // Arrange
            var form = new FormBuilder().Build();
            var expected = Guid.NewGuid();

            // Act
            form.Id = expected;
            var actual = form.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormTitleShouldGetAndSetValues()
        {
            // Arrange
            var form = new FormBuilder().Build();
            var expected = "Test Form";

            // Act
            form.Title = expected;
            var actual = form.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTopicToFormShouldWork()
        {
            // Arrange
            var expectedTopicTitle = "Test Topic";
            var expectedCount = 1;
            var form = new FormBuilder().Build();
            var topic = new TopicBuilder().WithTitle(expectedTopicTitle).Build();

            // Act
            form.Topics.Add(topic);
            var actualCount = form.Topics.Count();
            var actualTopic = form.Topics.FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreSame(topic, actualTopic);
        }

        [TestMethod]
        public void RemoveTopicToFormShouldWork()
        {
            // Arrange
            var expectedCount = 0;
            var topic = new TopicBuilder().Build();
            var form = new FormBuilder().WithTopic(topic).Build();

            // Act
            form.Topics.Remove(topic);
            var actualCount = form.Topics.Count();
            var actualTopic = form.Topics.FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreSame(null, actualTopic);
        }

        [TestMethod]
        public void RemoveInexistentTopicShouldFail()
        {
            // Arrange
            var falseTopic = new TopicBuilder().Build();
            var topic = new TopicBuilder().Build();
            var form = new FormBuilder().WithTopic(topic).Build();

            // Act
            var actual = form.Topics.Remove(falseTopic);

            Assert.IsFalse(actual);
        }
    }
}
