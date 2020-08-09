using SilpoBonus.core.offers;
using SilpoBonus.core.checkout;
using SilpoBonus.features.condition;
using SilpoBonus.features.disount;

namespace SilpoBonus.features
{
    public class DiscountOffer : Offer
    {
        IDiscount iDiscount;

        public DiscountOffer(IDiscount discount, ICondition iConition, DateTime expirationDate) : base(iCondition, expirationDate)
        {
            this.discount = discount;
        }

        public override void apply(Check check)
        {
            Discount discount = iDisount.CalcDiscount(check);
            int savedMoney = discount.product.price * discount.discount / 100;
            
            check.AddSavedMoney(savedMoney);
        }
    }
}