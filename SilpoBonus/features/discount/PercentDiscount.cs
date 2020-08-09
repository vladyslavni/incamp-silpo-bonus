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

        public Discount CalcDiscount(Check check)
        {
            return new Discount(product, percent);
        }
    }
}