namespace Bishop.Tests.Scenarios.ObjectBuilders
{
    using Bishop.Model.Entities;

    public class TopicBuilder : ObjectBuilder<Topic>
    {
        public TopicBuilder WithTitle(string title)
        {
            this.Instance.Title = title;
            return this;
        }

        public TopicBuilder WithQuestion(Question question)
        {
            this.Instance.Questions.Add(question);
            return this;
        }
    }
}
