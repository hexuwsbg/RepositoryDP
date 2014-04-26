using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public class Operation
    {
        private double numberA = 0;

        public double NumberA { set { numberA = value; } get { return numberA; } } 

        private double numberB = 0;

        public double NumberB { set { numberB = value; } get { return numberB; } }

        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }
}
