using SilpoBonus.core.offers;
using SilpoBonus.core.checkout;
using SilpoBonus.features.reward;

namespace SilpoBonus.features
{
    public class BonusOffer : Offer
    {
        IReward iReward;

        public BonusOffer(IReward reward, DateTime expirationDate) : base(expirationDate)
        {
            this.reward = reward;
        }

        public override void apply(Check check) 
        {
            int points = iReward.CalcPoint(check);
            check.AddPoints(points);    
        }
    }
}