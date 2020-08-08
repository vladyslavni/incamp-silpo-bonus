using System.Linq;
using System.Collections.Generic;
using System;

namespace SilpoBonusCore
{
    public class PercentDiscountOffer : Offer
    {
        public readonly Product product;
        public readonly int discount;
        public PercentDiscountOffer(Product product, int discount, DateTime expirationDate) : base(expirationDate)
        {
            this.product = product;
            this.discount = discount;
        }

        public override void apply(Check check)
        {
            List<Product> products = check.GetDiscountProducts(product);

            double divider = 100 / discount;
            products.Select(prod => prod.price)
                .Select(price => (int) (price / divider))
                .ToList()
                .ForEach(price => check.AddSavingMoney(price));
        }


        public override bool IsSatisfiesCondition(Check check)
        {
            return check.GetCostByProduct(product) > 0;
        }

    }
}