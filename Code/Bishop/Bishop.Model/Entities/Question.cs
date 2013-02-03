namespace Bishop.Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Bishop.Framework.Exceptions;

    public class Question
    {
        private readonly List<Answer> answers;

        public Question()
        {
            this.Text = string.Empty;
            this.answers = new List<Answer>();
        }

        [Key]
        public long Id { get; set; }

        public string Text { get; set; }

        public IList<Answer> Answers
        {
            get
            {
                return this.answers;
            }
        }

        public QuestionTypes QuestionType { get; set; }
    }
}
