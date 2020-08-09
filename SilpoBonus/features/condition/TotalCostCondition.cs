using SilpoBonus.core.checkout;

namespace SilpoBonus.features.condition
{
    public class TotalCostCondition : ICondition
    {
        private int totalCost;

        public TotalCostCondition(int totalCost)
        {
            this.totalCost = totalCost;
        }

        public override bool IsSatisfies(Check check)
        {
            return totalCost <= check.GetTotalCost();
        }
    }
}