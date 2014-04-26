using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    /// <summary>
    /// 策略模式： 是一种定义了一系列算法的方法，从概念上来看，所有这些算法完成的都是相同的工作，只是实现不同，它可以以相同的方式调用所有的算法，减少了
    /// 各种算法类与使用算法类之间的耦合。
    /// 策略模式的strategy类层次为context定义了一系列的可供重用的算法或行为。继承有助于取出这些算法的公共功能，另一个优点就是简化了单元测试，因为每个
    /// 算法都有自己的类，可以通过自己的接口单独测试
    /// </summary>
    public class RebateStrategy : ExpenseStrategy
    {
        private double rebate = 1d;

        public RebateStrategy( double rebate )
        {
            this.rebate = rebate;
        }

        public override double GetExpense(double money)
        {
            return money * rebate;
        }
    }
}
