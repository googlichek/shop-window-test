using Game.Core;

namespace Game.Health
{
    public class HealthData : BundleData<float>
    {
        internal HealthData()
        {
            CurrentValue = 100;
        }
    }
}
