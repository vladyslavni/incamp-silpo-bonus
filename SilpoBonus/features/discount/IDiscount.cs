namespace SilpoBonus.features.discount
{
    public interface IDiscount
    {
        Discount CalcDiscount(Check check);
    }
}