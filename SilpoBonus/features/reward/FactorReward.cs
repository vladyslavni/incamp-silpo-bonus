using SilpoBonus.core.checkout;

namespace SilpoBonus.features.reward
{
    public class FactorReward : IReward
    {
        public readonly int factor;

        public FactorReward(int factor)
        {
            this.factor = factor;
        }

        public override int CalcPoints(Check check)
        {
            int points = check.GetCostByCategory(product);
            return points * (factor - 1);   
        }
    }
}