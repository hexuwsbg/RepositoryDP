using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Finery : Person 
    {
        protected Person component;


        public void Decorate( Person component )
        {
            this.component = component;
        }

        public override void Show()
        {
            if ( this.component != null )
            {
                component.Show();
            }
        }
    }
}
