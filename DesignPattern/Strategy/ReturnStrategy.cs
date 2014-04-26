using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class ReturnStrategy : ExpenseStrategy
    {
        private double moneyCondition = 0d;
        private double moneyReturn = 0d;

        public ReturnStrategy( double moneyCondition, double moneyReturn )
        {
            this.moneyCondition = moneyCondition;
            this.moneyReturn = moneyReturn;
        }

        public override double GetExpense( double money )
        {
            double result = money;
            if ( money >= moneyCondition )
            {
                result = money - Math.Floor(money / moneyCondition) * moneyReturn;
            }
            return result;
        }
    }
}
