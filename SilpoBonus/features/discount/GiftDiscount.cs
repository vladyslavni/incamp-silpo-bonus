using SilpoBonus.core.checkout;

namespace SilpoBonus.features.discount
{
    public class GiftDiscount : IDiscount
    {
        public readonly Product product;
        public readonly Product gift;
        public readonly int percent;

        public GiftDiscount(Product product, Product gift, int percent)
        {
            this.product = product;
            this.gift = gift;
            this.percent = percent;
        }

        public Discount CalcDiscount(Check check)
        {
            return new Discount(gift, percent);
        }
    }
}