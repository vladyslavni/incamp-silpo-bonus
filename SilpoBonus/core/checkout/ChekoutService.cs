using System;
using System.Collections.Generic;
using System.Linq;
using SilpoBonus.core.enums;
using SilpoBonus.core.offers;

namespace SilpoBonus.core.checkout
{
    public class CheckoutService
    {
        private Check check;

        private List<Offer> offers = new List<Offer>();

        public void OpenCheck()
        {
            this.check = new Check();
        }

        public void AddProduct(Product product) 
        {
            if (check == null) {
                OpenCheck();
            }
            check.AddProduct(product);
        }

        public Check CloseCheck() {
            Check closedCheck = check;
            check = null;

            return closedCheck;
        }

        public void UseOffer() 
        {
            offers.ForEach(offer => offer.TryToApply(check));
        }

        public void AddOffer(Offer offer) 
        {
            offers.Add(offer);
        }
    }
}