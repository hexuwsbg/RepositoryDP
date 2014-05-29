using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main( string[] args )
        {
            //Person person = new Person("jason");
            //TShirts shirt = new TShirts();
            //BigTrousers bt = new BigTrousers();
            //shirt.Decorate(person);
            //bt.Decorate(shirt);
            //bt.Show();
            DateTime dt = new DateTime(2014,5,4,8,9,3);
            Console.WriteLine(dt.ToString("HH:mm:ss"));
            Console.Read();
        }
    }
}
