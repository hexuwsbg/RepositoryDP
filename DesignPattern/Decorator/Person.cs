using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Person
    {
        private string name;

        public Person( string name )
        {
            this.name = name;
        }

        public Person()
        {

        }

        public virtual void Show()
        {
            Console.WriteLine(string.Format("装扮的{0}", name));
        }
    }
}
