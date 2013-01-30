using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bishop.Model.Tests.ObjectMother
{
    abstract class ObjectMother<T> 
    {
        protected T instance;

        public ObjectMother()
        {
            this.Instantiate();
        }

        public abstract void Instantiate();        

        public T Get()
        { 
            return this.instance; 
        }
    }
}
