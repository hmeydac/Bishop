namespace Bishop.Tests.Scenarios.ObjectBuilders
{
    using System;

    public abstract class ObjectBuilder<T>
    {
        private readonly T instance;

        protected ObjectBuilder()
        {
            this.instance = Activator.CreateInstance<T>();
        }

        protected T Instance
        {
            get
            {
                return this.instance;
            }
        }

        public T Build()
        {
            return this.Instance;
        }
    }
}
