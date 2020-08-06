using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore
{
    public class AnyGoodsOffer
    {
        public readonly int totalCost;
        public readonly int points;

        public AnyGoodsOffer(int totalCost, int points) {
            this.totalCost = totalCost;
            this.points = points;
        }

    }
}