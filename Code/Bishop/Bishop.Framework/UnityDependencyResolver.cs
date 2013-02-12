namespace Bishop.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.Practices.Unity;

    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            this.container = container;
            this.TypesToResolveThroughUnity = new List<Type> { typeof(Controller) };
        }

        public List<Type> TypesToResolveThroughUnity { get; private set; }

        public object GetService(Type serviceType)
        {
            if (!this.ShouldResolveThroughUnity(serviceType))
            {
                return null;
            }

            return this.container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

        protected bool ShouldResolveThroughUnity(Type type)
        {
            return this.TypesToResolveThroughUnity.Any(type.IsSubclassOf);
        }
    }
}
