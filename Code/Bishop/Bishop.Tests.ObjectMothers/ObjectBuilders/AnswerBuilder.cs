namespace Bishop.Tests.Scenarios.ObjectBuilders
{
    using Bishop.Model.Entities;

    public class AnswerBuilder : ObjectBuilder<Answer>
    {
        public AnswerBuilder WithText(string text)
        {
            this.Instance.Text = text;
            return this;
        }
    }
}
