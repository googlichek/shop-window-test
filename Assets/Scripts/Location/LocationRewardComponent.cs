using Game.Core;
using UnityEngine;

namespace Game.Location
{
    public class LocationRewardComponent : MonoBehaviour, IReward
    {
        private string _reward;

        public bool DoWant()
        {
            var data = PlayerData.Instance.GetData<LocationData>();
            return string.IsNullOrEmpty(data.CurrentValue) && string.IsNullOrEmpty(data.ReservedValue);
        }

        public void SetValue(string value)
        {
            _reward = value;
        }

        public void ReserveChanges()
        {
            var data = PlayerData.Instance.GetData<LocationData>();
            data.ReservedValue = _reward;
        }

        public void ApplyChanges()
        {
            var data = PlayerData.Instance.GetData<LocationData>();
            data.CurrentValue = _reward;
            data.ReservedValue = string.Empty;
        }
    }
}
