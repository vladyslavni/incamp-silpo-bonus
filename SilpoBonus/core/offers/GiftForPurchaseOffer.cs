using System.Collections.Generic;
using System;
namespace SilpoBonusCore
{
    public class GiftForPurchaseOffer : Offer
    {
        public readonly Product product;
        public readonly Product gift;
        
        public GiftForPurchaseOffer(Product product, Product gift, DateTime expirationDate) : base(expirationDate)
        {
            this.product = product;
            this.gift = gift;
        }

        public override void apply(Check check) 
        {
            List<Product> products = check.GetSameProducts(product);
        
            products.ForEach(prod => check.AddProduct(gift));
        }

        public override bool IsSatisfiesCondition(Check check) 
        {
            return check.GetSameProducts(product).Count > 0;
        }

    }
}