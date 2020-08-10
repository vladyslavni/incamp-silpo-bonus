using SilpoBonus.core.checkout;
using System;
namespace SilpoBonus.features.discount
{
    public class GiftDiscount : IDiscount
    {
        public readonly Product product;
        public readonly Product gift;
        public GiftDiscount(Product product, Product gift)
        {
            this.product = product;
            this.gift = gift;
        }

        public int CalcDiscount(Check check)
        {
            int count = Math.Min(check.GetCountBy(product), check.GetCountBy(gift));

            return gift.price * count;
        }
    }
}