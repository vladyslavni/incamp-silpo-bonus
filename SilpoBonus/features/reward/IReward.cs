namespace SilpoBonus.features.reward
{
    public interface IReward
    {
        int CalcPoints(Check check);
    }
}