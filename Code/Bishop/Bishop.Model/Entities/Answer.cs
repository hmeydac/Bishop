namespace Bishop.Model.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Answer
    {
        public Answer()
        {
            this.Text = string.Empty;
            this.IsCorrectAnswer = false;
        }

        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCorrectAnswer { get; set; }

        public bool IsChecked { get; set; }

        public double Weight { get; set; }
    }
}
