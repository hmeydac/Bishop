namespace Bishop.Services
{
    using Bishop.Model.Entities;

    public interface IPublishedFormService
    {
        PublishedForm[] GetAllActive();
    }
}
