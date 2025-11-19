namespace Game.Core
{
    public interface ICost
    {
        bool CanAfford();

        void SetValue(string value);

        void Apply();
    }
}
