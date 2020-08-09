using System;
using SilpoBonus.core.offers;
using SilpoBonus.core.checkout;
using SilpoBonus.features.condition;
using SilpoBonus.features.discount;

namespace SilpoBonus.features.offers
{
    public class DiscountOffer : Offer
    {
        private IDiscount iDiscount;

        public DiscountOffer(IDiscount iDiscount, ICondition iCondition, DateTime expirationDate) : base(iCondition, expirationDate)
        {
            this.iDiscount = iDiscount;
        }

        public override void apply(Check check)
        {
            Discount discount = iDiscount.CalcDiscount(check);
            int savedMoney = discount.product.price * discount.percent / 100;
            
            check.AddSavedMoney(savedMoney);
        }
    }
}