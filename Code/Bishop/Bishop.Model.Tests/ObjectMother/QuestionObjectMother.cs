namespace Bishop.Model.Tests.ObjectMother
{
    using Bishop.Model.Entities;

    public class QuestionObjectMother : ObjectMother<Question>
    {
        public override Question CreateInstance()
        {
            return new Question();
        }

        public QuestionObjectMother WithText(string text)
        {
            this.Instance.Text = text;
            return this;
        }

        public QuestionObjectMother WithAnswer(Answer answer)
        {
            this.Instance.AddAnswer(answer);
            return this;
        }
    }
}
