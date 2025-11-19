namespace Game.Core
{
    public interface IReward
    {
        bool DoWant();

        void SetValue(string value);

        void ReserveChanges();

        void ApplyChanges();
    }
}
