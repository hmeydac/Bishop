namespace Bishop.Services
{
    using System;

    using Bishop.Model.Entities;

    public interface IFillingSessionService
    {
        FillingSession Get(Guid id);

        FillingSession StartNewSession();
    }
}