using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bishop.Model.Entities;

namespace Bishop.Model.Tests.ObjectMother
{
    class QuestionObjectMother : ObjectMother<Question>
    {
        public override void Instantiate()
        {
            this.instance = new Question();
        }

        public QuestionObjectMother WithText(string text)
        {
            this.instance.Text = text;
            return this;
        }
    }
}
