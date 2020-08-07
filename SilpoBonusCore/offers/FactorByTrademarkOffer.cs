using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore
{
    public class FactorByTrademarkOffer : Offer
    {
        public readonly Trademark trademark;
        public readonly int factor;
        
        public FactorByTrademarkOffer(Trademark trademark, int factor, DateTime expirationDate) : base(expirationDate)
        {
            this.trademark = trademark;
            this.factor = factor;
        }

        public override void apply(Check check) 
        {
            int points = check.GetCostByTrademark(trademark);
            check.AddPoints(points * (factor - 1));    
        }

        public override bool IsSatisfiesCondition(Check check) 
        {
            return check.GetCostByTrademark(trademark) > 0;
        }

    }
}