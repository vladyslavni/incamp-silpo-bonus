using SilpoBonus.core.checkout;

namespace SilpoBonus.features.reward
{
    public class FlatReward : IReward
    {
        public readonly int points;
        public readonly Product product;
        public FlatReward(int points, Product product)
        {
            this.points = points;
            this.product = product;
        }

        public int CalcPoints(Check check)
        {
            return check.GetCountBy(product) * points;
        }
    }
}