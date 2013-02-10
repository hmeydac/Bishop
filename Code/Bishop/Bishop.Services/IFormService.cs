namespace Bishop.Services
{
    using System;

    using Bishop.Model.Entities;

    public interface IFormService
    {
        Form[] GetAll();

        Form[] GetList();

        Form Get(Guid id);
    }
}