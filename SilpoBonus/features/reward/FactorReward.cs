using SilpoBonus.core.checkout;
using SilpoBonus.core.enums;

namespace SilpoBonus.features.reward
{
    public class FactorReward : IReward
    {
        public readonly int factor;
        public FactorReward(int factor)
        {
            this.factor = factor;
        }

        public int CalcPoints(Check check)
        {
            return check.GetTotalCost() * (factor - 1);   
        }
    }
}