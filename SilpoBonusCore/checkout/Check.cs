using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore
{
    public class Check
    {
        private List<Product> products = new List<Product>();
        private int points = 0;
        private int savingMoney = 0;
        public int GetTotalCost()
        {
            return products.Sum(product => product.price) - savingMoney;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public int GetTotalPoints() 
        {
            return GetTotalCost() + points;
        }

        public void AddPoints(int points) 
        {
            this.points += points;
        }

        public int GetCostByCategory(Category category) 
        {
            return products.Where(p => p.category == category)
                    .Select(p => p.price)
                    .Aggregate(0, (a, b) => a + b);
        }

        public int GetCostByTrademark(Trademark trademark) 
        {
            return products.Where(p => p.trademark == trademark)
                    .Select(p => p.price)
                    .Aggregate(0, (a, b) => a + b);
        }

        public int GetCostByProduct(Product product) 
        {
            return products.Where(p => p.Equals(product))
                    .Select(p => p.price)
                    .Aggregate(0, (a, b) => a + b);
        }
        
        public List<Product> GetDiscountProducts(Product product) 
        {
            return products.FindAll(p => p.Equals(product));
        }

        public void AddSavingMoney(int money)
        {
            this.savingMoney += money;
        }
    }
}