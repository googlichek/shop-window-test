namespace Game.Core
{
    public interface ICost
    {
        bool CanAfford();

        void ApplyChanges();
    }
}
