using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore
{
    public class Check
    {
        private List<Product> products = new List<Product>();

        public int GetTotalCost()
        {
            return products.Sum(product => product.price);
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

    }
}