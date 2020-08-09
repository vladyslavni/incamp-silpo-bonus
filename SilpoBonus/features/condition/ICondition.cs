using SilpoBonus.core.checkout;

namespace SilpoBonus.features.condition 
{
    public interface ICondition
    {
        bool IsSatisfies(Check check); 
    }
}