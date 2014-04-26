using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class NormalStrategy : ExpenseStrategy
    {
        public override double GetExpense(double money)
        {
            return money;
        }
    }
}
