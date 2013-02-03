namespace Bishop.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Answer
    {
        public Answer()
        {
            this.Text = string.Empty;
            this.IsCorrectAnswer = false;
        }

        [Key]
        public long Id { get; set; }

        public string Text { get; set; }

        public bool IsCorrectAnswer { get; set; }

        public double Weight { get; set; }
    }
}
