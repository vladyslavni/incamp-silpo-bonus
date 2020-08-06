using System;

namespace SilpoBonusCore
{
    public class Product
    {
        public readonly int price;
        public readonly string name;
        public readonly Category category;

        public Product(int price, string name, Category category)
        {
            this.price = price;
            this.name = name;
            this.category = category;
        }
    
        public Product(int price, String name) : this(price, name, 0) {
            this.price = price;
            this.name = name;
        }

    }
}