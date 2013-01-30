using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bishop.Model.Entities;

namespace Bishop.Model.Tests.ObjectMother
{
    class SurveyObjectMother : ObjectMother<Survey>
    {
        public override void Instantiate()
        {
            this.instance = new Survey();
        }
    }
}
