using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class ExpenseContext
    {
        private ExpenseStrategy es = null;

        public ExpenseContext( string strategyType )
        {
            switch ( strategyType )
            {
                case "满300返100":
                    es = new ReturnStrategy(300d, 100d);
                    break;
                case "打八折":
                    es = new RebateStrategy(0.8);
                    break;
                default :
                    es = new  NormalStrategy();
                    break;
            }
        }

        public double GetResult( double money )
        {
            return es.GetExpense(money);
        }
    }
}
