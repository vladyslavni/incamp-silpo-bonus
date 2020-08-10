using System;
using Xunit;
using SilpoBonus.core.checkout;
using SilpoBonus.core.enums;
using SilpoBonus.core.offers;

using SilpoBonus.features.condition;
using SilpoBonus.features.discount;
using SilpoBonus.features.offers;
using SilpoBonus.features.reward;

namespace SilpoBonus.Tests
{
    public class CheckoutServiceTest
    {

        private CheckoutService checkoutService;
        private Product milk_7;
        private Product milk_11;
        private Product bred_3;
        private DateTime offer_time_1d;
        private DateTime offer_time_expiered;

        public CheckoutServiceTest()
        {
            this.checkoutService = new CheckoutService();
            this.milk_11 = new Product(11, "Milk", Trademark.AMSZ);
            this.milk_7 = new Product(7, "Milk", Category.MILK);
            this.bred_3 = new Product(3, "Bread");
            this.offer_time_1d = DateTime.Now.AddDays(2);
            this.offer_time_expiered = new DateTime(1992, 2, 1);

            checkoutService.OpenCheck();
        }
       
        [Fact]
        public void closeCheck__withOneProduct()
        {
            checkoutService.AddProduct(milk_7);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalCost(), 7);
        }

        [Fact]
        public void closeCheck__withTwoProducts()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalCost(), 10);
        }

        [Fact]
        public void addProduct__whenCheckIsClosed__opensNewCheck() 
        {
            checkoutService.AddProduct(milk_7);
            Check milkCheck = checkoutService.CloseCheck();
            Assert.Equal(milkCheck.GetTotalCost(), 7);

            checkoutService.AddProduct(bred_3);
            Check bredCheck = checkoutService.CloseCheck();
            Assert.Equal(bredCheck.GetTotalCost(), 3);
        }

        [Fact]
        public void closeCheck__calcTotalPoints() 
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 10);
        }

        [Fact]
        public void useOffer__addOfferPoints() {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);

            TotalCostCondition condition = new TotalCostCondition(6);
            FlatReward reward = new FlatReward(2, milk_7);
            BonusOffer offer = new BonusOffer(reward, condition, offer_time_1d);
            checkoutService.AddOffer(offer);

            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 12);
        }

        [Fact]
        public void useOffer__whenCostLessThanRequired__doNothing() {
            checkoutService.AddProduct(bred_3);

            TotalCostCondition condition = new TotalCostCondition(6);
            FlatReward reward = new FlatReward(2, bred_3);
            BonusOffer offer = new BonusOffer(reward, condition, offer_time_1d);
            checkoutService.AddOffer(offer);

            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 3);
        }

        [Fact]
        void useOffer__factorByCategory() {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);

            ICondition condition = new ByCategoryCondition(Category.MILK);
            IReward reward = new FactorReward(2, milk_7);
            BonusOffer offer = new BonusOffer(reward, condition, offer_time_1d);
            checkoutService.AddOffer(offer);

            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 45);
        }

        [Fact]
        void useOffer__flatByTrademark() {
            checkoutService.AddProduct(milk_11);
            checkoutService.AddProduct(milk_11);
            checkoutService.AddProduct(bred_3);

            ICondition condition = new ByTrademarkCondition(Trademark.AMSZ);
            IReward reward = new FlatReward(2, milk_11);
            BonusOffer offer = new BonusOffer(reward, condition, offer_time_1d);
            checkoutService.AddOffer(offer);

            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 29);
        }

        [Fact]
        void useOffer__flatByProduct() {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);

            ICondition condition = new ByProductCondition(milk_7);
            IReward reward = new FlatReward(2, milk_7);
            BonusOffer offer = new BonusOffer(reward, condition, offer_time_1d);
            checkoutService.AddOffer(offer);

            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 21);
        }

        [Fact]
        void useOffer__DiscountByProduct() {
            checkoutService.AddProduct(milk_11);
            checkoutService.AddProduct(milk_11);
            checkoutService.AddProduct(bred_3);

            ByProductCondition condition = new ByProductCondition(milk_11);
            IDiscount discount = new PercentDiscount(milk_11, 50);
            DiscountOffer offer = new DiscountOffer(discount, condition, offer_time_1d);
            checkoutService.AddOffer(offer);

            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalCost(), 14);
        }

        [Fact]
        void useOffer__GiftByProduct() {
            checkoutService.AddProduct(milk_11);
            checkoutService.AddProduct(milk_11);
            checkoutService.AddProduct(bred_3);

            ByProductCondition condition = new ByProductCondition(milk_11);
            IDiscount discount = new GiftDiscount(milk_11, bred_3);
            DiscountOffer offer = new DiscountOffer(discount, condition, offer_time_1d);
            checkoutService.AddOffer(offer);

            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 22);
            Assert.Equal(check.GetTotalCost(), 22);
        }

        [Fact]
        void offer__timeExpiered() {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);
            
            TotalCostCondition condition = new TotalCostCondition(6);
            FlatReward reward = new FlatReward(2, milk_7);
            BonusOffer offer = new BonusOffer(reward, condition, offer_time_expiered);
            checkoutService.AddOffer(offer);
            
            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 10);
        }
    }
}
