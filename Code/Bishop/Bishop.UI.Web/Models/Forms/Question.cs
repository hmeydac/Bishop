namespace Bishop.UI.Web.Models.Forms
{
    using System.Collections.Generic;

    public class Question
    {
        public Question()
        {
            this.Answers = new List<Answer>();
        }

        public double Id { get; set; }

        public string Text { get; set; }

        public QuestionTypes QuestionType { get; set; }

        public List<Answer> Answers { get; set; }

        public object SelectedAnswer { get; set; }
    }
}