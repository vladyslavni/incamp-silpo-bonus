using System;
using SilpoBonus.core.offers;
using SilpoBonus.core.checkout;
using SilpoBonus.features.condition;
using SilpoBonus.features.reward;

namespace SilpoBonus.features.offers
{
    public class BonusOffer : Offer
    {
        private IReward iReward;
        private ICondition iCondition;

        public BonusOffer(IReward iReward, ICondition iCondition, DateTime expirationDate) : base(iCondition, expirationDate)
        {
            this.iReward = iReward;
            this.iCondition = iCondition;
        }

        public override void apply(Check check) 
        {
            int points = iReward.CalcPoints(check);
            check.AddPoints(points);    
        }
    }
}