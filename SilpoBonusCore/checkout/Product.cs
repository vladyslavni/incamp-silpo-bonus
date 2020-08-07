using System;

namespace SilpoBonusCore
{
    public class Product
    {
        public readonly int price;
        public readonly string name;
        public readonly Category category;
        public readonly Trademark trademark;
        public Product(int price, string name, Category category, Trademark trademark)
        {
            this.price = price;
            this.name = name;
            this.category = category;
            this.trademark = trademark;
        }
    
        public Product(int price, string name, Category category) : this(price, name, category, Trademark.NONE) 
        {}
        public Product(int price, string name, Trademark trademark) : this(price, name, Category.NONE, trademark) 
        {}    
        public Product(int price, String name) : this(price, name, Category.NONE, Trademark.NONE) 
        {}

        public override bool Equals(Object obj)
        {
            if (obj is Product) {
                Product product = (Product) obj;

                if ((this.name == product.name) && (this.price == product.price) 
                    && (this.category == product.category) && (this.trademark == product.trademark)) 
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}