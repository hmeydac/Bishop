namespace Bishop.Tests.Scenarios.ObjectMothers
{
    using Bishop.Repositories;
    using Bishop.Services;

    using Microsoft.Practices.Unity;

    using Moq;

    public class FillingSessionServiceMother : ObjectMother
    {
        public Mock<IFillingSessionService> GetMockedService()
        {
            return new Mock<IFillingSessionService>(MockBehavior.Strict);
        }
    }
}
