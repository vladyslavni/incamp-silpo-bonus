using System;
using System.Collections.Generic;
using System.Linq;
using SilpoBonus.core.enums;

namespace SilpoBonus.core.checkout
{
    public class Check
    {
        private List<Product> products = new List<Product>();
        private int points = 0;
        private int savedMoney = 0;

        public int GetTotalCost()
        {
            return products.Sum(product => product.price) - savedMoney;
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

        public void AddSavedMoney(int savedMoney)
        {
            this.savedMoney += savedMoney;
        }

        public int GetCostBy(Category category) 
        {
            return products.Where(p => p.category == category)
                    .Select(p => p.price)
                    .Sum();
        }

        public int GetCostBy(Trademark trademark) 
        {
            return products.Where(p => p.trademark == trademark)
                    .Select(p => p.price)
                    .Sum();
        }

        public int GetCostBy(Product product) 
        {
            return products.Where(p => p.Equals(product))
                    .Select(p => p.price)
                    .Sum();
        }
        
        public int GetCountBy(Product product) 
        {
            return products.FindAll(p => p.Equals(product)).Count;      
        }
    }
}