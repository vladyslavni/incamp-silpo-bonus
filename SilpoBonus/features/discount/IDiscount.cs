using SilpoBonus.core.checkout;

namespace SilpoBonus.features.discount
{
    public interface IDiscount
    {
        int CalcDiscount(Check check);
    }
}