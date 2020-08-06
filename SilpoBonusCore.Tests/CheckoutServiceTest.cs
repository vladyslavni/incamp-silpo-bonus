using System;
using Xunit;

namespace SilpoBonusCore.Tests
{
    public class CheckoutServiceTest
    {

        private CheckoutService checkoutService;
        private Product milk_7;
        private Product bred_3;
        private DateTime offer_time_1d;
        private DateTime offer_time_expiered;

        public CheckoutServiceTest()
        {
            this.checkoutService = new CheckoutService();
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

            checkoutService.AddOffer(new AnyGoodsOffer(6, 2, offer_time_1d));
            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 12);
        }

        [Fact]
        public void useOffer__whenCostLessThanRequired__doNothing() {
            checkoutService.AddProduct(bred_3);

            checkoutService.AddOffer(new AnyGoodsOffer(6, 2, offer_time_1d));
            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 3);
        }

        [Fact]
        void useOffer__factorByCategory() {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);

            checkoutService.AddOffer(new FactorByCategoryOffer(Category.MILK, 2, offer_time_1d));
            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 31);
        }

        [Fact]
        void offer__timeExpiered() {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bred_3);

            checkoutService.AddOffer(new FactorByCategoryOffer(Category.MILK, 2, offer_time_expiered));
            checkoutService.UseOffer();
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 17);
        }
    }
}
