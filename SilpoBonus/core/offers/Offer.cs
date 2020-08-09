using System;
using SilpoBonus.features.condition;
using SilpoBonus.core.checkout;

namespace SilpoBonus.core.offers {
    public abstract class Offer
    {
        public ICondition iCondition;
        public readonly DateTime expirationDate;

        public Offer(ICondition iCondition, DateTime expirationDate) 
        {
            this.iCondition = iCondition;
            this.expirationDate = expirationDate;
        }
        
        public abstract void apply(Check check);
    
        public bool IsValid() 
        {
            return expirationDate > DateTime.Now;
        }

        public void TryToApply(Check check)
        {
            if (iCondition.IsSatisfies(check) && IsValid())
            {
                apply(check);
            }
        }
    }
}