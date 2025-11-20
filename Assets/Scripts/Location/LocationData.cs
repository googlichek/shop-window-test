using Game.Core;

namespace Game.Location
{
    public class LocationData : BundleData<string>
    {
        internal LocationData()
        {
            CurrentValue = "Forest";
        }
    }
}
