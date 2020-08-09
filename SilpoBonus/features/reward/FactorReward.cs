using SilpoBonus.core.checkout;
using SilpoBonus.core.enums;

namespace SilpoBonus.features.reward
{
    public class FactorReward : IReward
    {
        public readonly int factor;
        public readonly Category category;
        public FactorReward(int factor, Category category)
        {
            this.factor = factor;
            this.category = category;
        }

        public int CalcPoints(Check check)
        {
            int points = check.GetCostByCategory(category);
            return points * (factor - 1);   
        }
    }
}