namespace Game.Core
{
    public interface IReward
    {
        void SetValue(string value);

        void Apply();
    }
}
