namespace Bishop.UI.Web.Models.Forms
{
    using System.Collections.Generic;

    public class UserForm
    {
        public UserForm()
        {
            this.Topics = new List<Topic>();
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public List<Topic> Topics { get; set; }
    }
}