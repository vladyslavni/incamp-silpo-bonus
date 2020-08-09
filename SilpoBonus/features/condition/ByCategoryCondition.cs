using SilpoBonus.core.enums;
using SilpoBonus.core.checkout;

namespace SilpoBonus.features.condition
{
    public class ByCategoryCondition : ICondition
    {
        private Category category;

        public ByCategoryCondition(Category category)
        {
            this.category = category;
        }

        public bool IsSatisfies(Check check)
        {
            return check.GetCostByCategory(category) > 0;
        }
    }
}