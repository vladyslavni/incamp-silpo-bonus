using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore
{
    public class FactorByCategoryOffer : AnyGoodsOffer
    {
        public readonly Category category;
        public readonly int factor;

        public FactorByCategoryOffer(Category category, int factor) : base(0, 0) {
            this.category = category;
            this.factor = factor;
        }

    }
}