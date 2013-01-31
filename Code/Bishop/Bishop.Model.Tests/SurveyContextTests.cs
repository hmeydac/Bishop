namespace Bishop.Model.Tests
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SurveyContextTests
    {
        [TestMethod]
        public void SurveyContextDefaultConstructorShouldWork()
        {
            // Act
            var context = new SurveyContext();
            var surveys = context.Surveys;
            var topics = context.Topics;
            var answers = context.Answers;
            var questions = context.Questions;

            var survey = context.Surveys.FirstOrDefault();
            var topic = context.Topics.FirstOrDefault();
            var answer = context.Answers.FirstOrDefault();
            var question = context.Questions.FirstOrDefault();

            // Assert
            Assert.IsNotNull(surveys);
            Assert.IsNotNull(topics);
            Assert.IsNotNull(questions);
            Assert.IsNotNull(answers);
        }
    }
}
