using SilpoBonus.core.enums;
using SilpoBonus.core.checkout;

namespace SilpoBonus.features.condition
{
    public class ByTrademarkCondition : ICondition
    {
        private Trademark trademark;

        public TotalCostCondition(Trademark trademark)
        {
            this.trademark = trademark;
        }

        public override bool IsSatisfies(Check check)
        {
            return check.GetCostByTrademark(trademark) > 0;
        }
    }
}