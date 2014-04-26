using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    //除法
    public class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if ( NumberB == 0 )
            {
                throw new Exception("The divisor cannot be zero");
            }
            result = NumberA / NumberB;
            return result;
        } 
    }
}
