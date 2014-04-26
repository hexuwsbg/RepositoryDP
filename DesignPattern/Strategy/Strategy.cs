using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public abstract class ExpenseStrategy
    {
        public abstract double GetExpense(double money);
    }
}
