namespace Bishop.Model.Entities
{
    public class Question
    {
        public Question()
        {
            this.Text = string.Empty;
        }

        public int Id { get; set; }

        public string Text { get; set; }
    }
}
