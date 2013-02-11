namespace Bishop.Services
{
    using System;
    using System.Linq;

    using Bishop.Model.Entities;
    using Bishop.Repositories;

    public class FillingSessionService : EntityService, IFillingSessionService
    {
        public FillingSessionService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public FillingSession[] GetActiveSessions()
        {
            return this.UnitOfWork.Query<FillingSession>(this.GetIncludeNames()).Where(f => f.IsActive).ToArray();
        }

        public FillingSession Get(Guid id)
        {
            return this.UnitOfWork.Query<FillingSession>().FirstOrDefault(f => f.Id.Equals(id));
        }

        public FillingSession StartSession(FillingSession session)
        {
            this.UnitOfWork.Add<FillingSession>(session);
            this.UnitOfWork.Commit();
            return session;
        }

        protected override string[] GetIncludeNames()
        {
            return new[] { "PublishedForm" };
        }

        public FillingSession StartNewSession()
        {
            var session = new FillingSession { Id = Guid.NewGuid(), IsActive = true };
            this.UnitOfWork.Add(session);
            this.UnitOfWork.Commit();
            return session;
        }
    }
}
