namespace Bishop.Model.Tests.ObjectMother
{
    public abstract class ObjectMother<T>
    {
        private readonly T instance;

        protected ObjectMother()
        {
            this.instance = this.CreateInstance();
        }

        protected T Instance
        {
            get
            {
                return this.instance;
            }
        }

        public abstract T CreateInstance();

        public T Build()
        {
            return this.Instance;
        }
    }
}
