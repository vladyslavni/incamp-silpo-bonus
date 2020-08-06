using System;

namespace SilpoBonusCore {
    public abstract class Offer
    {
        public readonly DateTime expirationDate;

        public Offer(DateTime expirationDate) 
        {
            this.expirationDate = expirationDate;
        }
        public abstract void apply(Check check);
    
        public bool isValid() 
        {
            return expirationDate >= DateTime.Now;
        }
    }
}