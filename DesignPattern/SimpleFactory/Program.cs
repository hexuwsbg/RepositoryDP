using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class Program
    {
        static void Main( string[] args )
        {
            //Console.WriteLine("Please enter the number A:");
            //string strNumberA = Console.ReadLine();
            //Console.WriteLine("Please enter operator(+ , -, *, /):");
            //string strOperator = Console.ReadLine();
            //Console.WriteLine("Please enter the number B:");
            //string strNumberB = Console.ReadLine();
            //Operation oper = OperationFactory.CreateOperation(strOperator);
            //oper.NumberA = Convert.ToDouble(strNumberA);
            //oper.NumberB = Convert.ToDouble(strNumberB);
            //Console.WriteLine(string.Format("The result is {0}.", oper.GetResult()));
            //Console.ReadLine();
            string s = "19:50:33:000";
            Console.WriteLine(s.PadLeft(12, '0'));
            Console.ReadLine();
        }
    }
}
