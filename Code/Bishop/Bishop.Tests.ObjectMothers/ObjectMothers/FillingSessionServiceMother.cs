namespace Bishop.Tests.Scenarios.ObjectMothers
{
    using Bishop.Repositories;
    using Bishop.Services;

    using Microsoft.Practices.Unity;

    using Moq;

    public class FillingSessionServiceMother : InjectionObjectMother
    {
        public FillingSessionServiceMother(IUnityContainer container)
            : base(container)
        {
        }

        public Mock<IFillingSessionService> GetMockedService()
        {
            return new Mock<IFillingSessionService>(MockBehavior.Strict);
        }

        public FillingSessionService GetService()
        {
            if (!this.Container.IsRegistered<IUnitOfWork>())
            {
                this.Container.RegisterInstance(new Mock<IUnitOfWork>(MockBehavior.Strict).Object);
            }

            return this.Container.Resolve<FillingSessionService>();
        }
    }
}
