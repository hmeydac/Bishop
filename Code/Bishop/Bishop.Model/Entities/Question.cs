namespace Bishop.Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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
        public double Id { get; set; }

        public string Text { get; set; }

        public IEnumerable<Answer> Answers
        {
            get
            {
                return this.answers;
            }
        }

        public QuestionTypes QuestionType { get; set; }

        public void AddAnswer(Answer answer)
        {
            this.answers.Add(answer);
        }

        public void RemoveAnswer(Answer answer)
        {
            if (!this.answers.Contains(answer))
            {
                throw new NotFoundException("Could not find Topic to remove.");
            }

            this.answers.Remove(answer);
        }
    }
}
