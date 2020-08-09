using System;

namespace SilpoBonus.core.offers {
    public abstract class Offer
    {
        public readonly DateTime expirationDate;

        public Offer(DateTime expirationDate) 
        {
            this.expirationDate = expirationDate;
        }
        
        public abstract void apply(Check check);
    
        public abstract bool IsSatisfiesCondition(Check check);

        public bool IsValid() 
        {
            return expirationDate > DateTime.Now;
        }

        public void TryToApply(Check check)
        {
            if (IsSatisfiesCondition(check) && IsValid()) {
                apply(check);
            }
        }
    }
}