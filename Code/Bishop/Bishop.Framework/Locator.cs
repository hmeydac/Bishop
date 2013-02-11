namespace Bishop.Framework
{
    using Microsoft.Practices.Unity;

    public class Locator
    {
        private readonly IUnityContainer container;

        public Locator(IUnityContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>()
        {
            return this.container.Resolve<T>();
        }

        public void RegisterInstance<T>(T instance)
        {
            this.container.RegisterInstance(instance);
        }

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            this.container.RegisterType<TFrom, TTo>();
        }
    }
}
