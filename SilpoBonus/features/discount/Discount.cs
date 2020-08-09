using SilpoBonus.core.checkout;

namespace SilpoBonus.features
{
    public class Discount
    {
        public readonly Product product;
        public readonly int percent;
        public Discount(Product product, int percent)
        {
            this.product = product;
            this.percent = percent;
        }

        public bool isDiscountedProduct(Product prod)
        {
            return product == prod;
        }
    }
}