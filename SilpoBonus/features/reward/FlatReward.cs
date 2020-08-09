using SilpoBonus.core.checkout;

namespace SilpoBonus.features.reward
{
    public class FlatReward : IReward
    {
        public readonly int points;

        public FlatReward(int points)
        {
            this.points = points;
        }

        public override int CalcPoints(Check check)
        {
            return check.GetTotalCost() + points;
        }
    }
}