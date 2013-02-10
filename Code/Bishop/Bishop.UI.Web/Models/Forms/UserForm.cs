namespace Bishop.UI.Web.Models.Forms
{
    using System;
    using System.Collections.Generic;

    public class UserForm
    {
        public UserForm()
        {
            this.Topics = new List<Topic>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<Topic> Topics { get; set; }
    }
}