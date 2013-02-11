namespace Bishop.Tests.Scenarios.ObjectMothers
{
    using Bishop.Model.Entities;
    using Bishop.Tests.Scenarios.ObjectBuilders;

    public class TopicMother : ObjectMother
    {
        public Topic GetDefaultTopic(string title)
        {
            var topic = new TopicBuilder()
                .WithTitle(title)
                .WithQuestion(this.GetDefaultQuestion("Question 1"))
                .WithQuestion(this.GetDefaultQuestion("Question 2"))
                .WithQuestion(this.GetDefaultQuestion("Question 3"))
                .WithQuestion(this.GetDefaultQuestion("Question 4"))
                .WithQuestion(this.GetDefaultQuestion("Question 5"))
                .Build();

            return topic;
        }

        private Question GetDefaultQuestion(string text)
        {
            return new QuestionBuilder()
                  .WithText(text)
                  .WithAnswer(new Answer { Text = "1" })
                  .WithAnswer(new Answer { Text = "2" })
                  .WithAnswer(new Answer { Text = "3" })
                  .WithAnswer(new Answer { Text = "4" })
                  .WithAnswer(new Answer { Text = "5" })
                  .Build();
        }
    }
}
