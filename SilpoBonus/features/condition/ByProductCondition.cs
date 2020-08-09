using SilpoBonus.core.checkout;

namespace SilpoBonus.features.condition
{
    public class ByProductCondition : ICondition
    {
        private Product product;

        public ByProductCondition(Product product)
        {
            this.product = product;
        }

        public bool IsSatisfies(Check check)
        {
            return check.GetCostByProduct(product) > 0;
        }
    }
}