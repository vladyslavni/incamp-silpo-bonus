using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore
{
    public class FactorByCategoryOffer : Offer
    {
        public readonly Category category;
        public readonly int factor;
        
        public FactorByCategoryOffer(Category category, int factor, DateTime expirationDate) : base(expirationDate)
        {
            this.category = category;
            this.factor = factor;
        }

        public override void apply(Check check) 
        {
            int points = check.GetCostByCategory(category);
            check.AddPoints(points * (factor - 1));    
        }

        public override bool IsSatisfiesCondition(Check check) 
        {
            return check.GetCostByCategory(category) > 0;
        }

    }
}