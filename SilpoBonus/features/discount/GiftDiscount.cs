using SilpoBonus.core.checkout;

namespace SilpoBonus.features.discount
{
    public class GiftDiscount : IDiscount
    {
        public readonly Product gift;

        public GiftDiscount(Product gift)
        {
            this.gift = gift;
        }

        public Discount CalcDiscount(Check check)
        {
            return new Discount(gift, 100);
        }
    }
}