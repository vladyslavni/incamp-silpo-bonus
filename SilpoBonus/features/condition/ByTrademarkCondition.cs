using SilpoBonus.core.enums;
using SilpoBonus.core.checkout;

namespace SilpoBonus.features.condition
{
    public class ByTrademarkCondition : ICondition
    {
        private Trademark trademark;

        public ByTrademarkCondition(Trademark trademark)
        {
            this.trademark = trademark;
        }

        public bool IsSatisfies(Check check)
        {
            return check.GetCostBy(trademark) > 0;
        }
    }
}