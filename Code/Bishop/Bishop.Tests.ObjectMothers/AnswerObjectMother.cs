namespace Bishop.Tests.ObjectMothers
{
    using Bishop.Model.Entities;

    public class AnswerObjectMother : ObjectMother<Answer>
    {
        public override Answer CreateInstance()
        {
            return new Answer();
        }

        public AnswerObjectMother WithText(string text)
        {
            this.Instance.Text = text;
            return this;
        }
    }
}
