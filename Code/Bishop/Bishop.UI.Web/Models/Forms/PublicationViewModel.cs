namespace Bishop.UI.Web.Models.Forms
{
    using System;

    using Bishop.Model.Entities;

    public class PublicationViewModel
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public string Title { get; set; }

        public Form Form { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}