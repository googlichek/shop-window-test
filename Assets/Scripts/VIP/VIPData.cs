using System;
using Game.Core;

namespace Game.VIP
{
    public class VIPData : BundleData<TimeSpan>
    {
        internal VIPData()
        {
            CurrentValue = TimeSpan.FromSeconds(45);
        }
    }
}
