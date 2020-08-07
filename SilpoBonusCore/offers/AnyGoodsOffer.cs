using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore
{
    public class AnyGoodsOffer : Offer
    {
        public readonly int totalCost;
        public readonly int points;

        public AnyGoodsOffer(int totalCost, int points, DateTime expirationDate) : base(expirationDate)
        {
            this.totalCost = totalCost;
            this.points = points;
        }

        public override void apply(Check check)
        {
            if (totalCost <= check.GetTotalCost()) {
                    check.AddPoints(points);
            }
        }

        public override bool IsSatisfiesCondition(Check check) 
        {
            return check.GetTotalCost() > totalCost;
        }

    }
}