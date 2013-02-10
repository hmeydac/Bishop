namespace Bishop.Tests.Scenarios.ObjectBuilders
{
    using Bishop.Model.Entities;

    public class QuestionBuilder : ObjectBuilder<Question>
    {
        public QuestionBuilder WithText(string text)
        {
            this.Instance.Text = text;
            return this;
        }

        public QuestionBuilder WithAnswer(Answer answer)
        {
            this.Instance.Answers.Add(answer);
            return this;
        }
    }
}
