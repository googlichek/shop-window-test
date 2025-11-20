using Game.Core;

namespace Game.Gold
{
    public class GoldData : BundleData<float>
    {
        internal GoldData()
        {
            CurrentValue = 100;
        }
    }
}
