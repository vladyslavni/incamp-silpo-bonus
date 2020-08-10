using SilpoBonus.core.checkout;
using SilpoBonus.core.enums;
using System;
using System.Collections.Generic;

namespace SilpoBonus.features.reward
{
    public class FactorReward : IReward
    {
        private int factor;
        private Product product;
        public FactorReward(int factor, Product product)
        {
            this.factor = factor;
            this.product = product;
        }

        public int CalcPoints(Check check)
        {
            return check.GetCostBy(product) * (factor - 1);   
        }
    }
}