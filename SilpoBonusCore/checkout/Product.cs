using System;

namespace SilpoBonusCore
{
    public class Product
    {
        public readonly int price;
        public readonly string name;

        public Product(int price, string name)
        {
            this.price = price;
            this.name = name;
        }
    }
}