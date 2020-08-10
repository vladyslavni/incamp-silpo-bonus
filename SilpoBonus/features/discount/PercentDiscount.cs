using SilpoBonus.core.checkout;

namespace SilpoBonus.features.discount
{
    public class PercentDiscount : IDiscount
    {
        public readonly Product product;
        public readonly int percent;

        public PercentDiscount(Product product, int percent)
        {
            this.product = product;
            this.percent = percent;
        }

        public int CalcDiscount(Check check)
        {
            return (int) (check.GetCostBy(product) / (100 / percent));
        }
    }
}