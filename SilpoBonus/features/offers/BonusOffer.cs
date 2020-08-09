using SilpoBonus.core.offers;
using SilpoBonus.core.checkout;
using SilpoBonus.features.condition;
using SilpoBonus.features.reward;

namespace SilpoBonus.features
{
    public class BonusOffer : Offer
    {
        IReward iReward;

        public BonusOffer(IReward iReward, ICondition iConition, DateTime expirationDate) : base(iCondition, expirationDate)
        {
            this.iReward = iReward;
        }

        public override void apply(Check check) 
        {
            int points = iReward.CalcPoint(check);
            check.AddPoints(points);    
        }
    }
}