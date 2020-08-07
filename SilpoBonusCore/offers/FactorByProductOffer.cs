using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore
{
    public class FactorByProductOffer : Offer
    {
        public readonly Product product;
        public readonly int factor;
        
        public FactorByProductOffer(Product product, int factor, DateTime expirationDate) : base(expirationDate)
        {
            this.product = product;
            this.factor = factor;
        }

        public override void apply(Check check) 
        {
            int points = check.GetCostByProduct(product);
            check.AddPoints(points * (factor - 1));    
        }

        public override bool IsSatisfiesCondition(Check check) 
        {
            return check.GetCostByProduct(product) > 0;
        }

    }
}