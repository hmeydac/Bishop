namespace Bishop.Tests.Scenarios.ObjectMothers
{
    using Microsoft.Practices.Unity;

    public abstract class InjectionObjectMother
    {
        protected IUnityContainer Container;

        protected InjectionObjectMother(IUnityContainer container)
        {
            this.Container = container;
        }
    }
}
