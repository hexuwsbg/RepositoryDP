using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class BigTrousers : Finery
    {
        public override void Show()
        {
            Console.WriteLine("Big trousers");
            base.Show();
        }
    }
}
