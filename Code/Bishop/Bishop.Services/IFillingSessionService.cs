namespace Bishop.Services
{
    using Bishop.Model.Entities;

    public interface IFillingSessionService
    {
        FillingSession[] GetActiveSessions();

        FillingSession StartNewSession();
    }
}