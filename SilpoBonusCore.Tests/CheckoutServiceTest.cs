using System;
using Xunit;

namespace SilpoBonusCore.Tests
{
    public class CheckoutServiceTest
    {

        private CheckoutService checkoutService;
        private Product milk_7;
        private Product bred_3;

        public CheckoutServiceTest()
        {
            this.checkoutService = new CheckoutService();
            this.milk_7 = new Product(7, "Milk");
            this.bred_3 = new Product(3, "Bread");
        
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


    }
}
