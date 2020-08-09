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

        public bool IsSatisfies(Check check)
        {
            return totalCost <= check.GetTotalCost();
        }
    }
}