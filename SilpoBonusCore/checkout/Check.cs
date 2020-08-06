using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore
{
    public class Check
    {
        private List<Product> products = new List<Product>();
        private int points = 0;

        public int GetTotalCost()
        {
            return products.Sum(product => product.price);
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
    }
}