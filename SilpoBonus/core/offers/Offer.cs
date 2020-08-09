using System;
using SilpoBonus.features.condition;

namespace SilpoBonus.core.offers {
    public abstract class Offer
    {
        private ICondition iCondition;
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
            if (iCondition.IsSatisfies(check) && IsValid()) {
                apply(check);
            }
        }
    }
}