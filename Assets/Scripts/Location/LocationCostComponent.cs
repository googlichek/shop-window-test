using Game.Core;
using UnityEngine;

namespace Game.Location
{
    public class LocationCostComponent : MonoBehaviour, ICost
    {
        private string _cost;

        public bool CanAfford()
        {
            var data = PlayerData.Instance.GetData<LocationData>();
            return data.CurrentValue.Equals(_cost) && string.IsNullOrEmpty(data.ReservedValue);
        }

        public void SetValue(string value)
        {
            _cost = value;
        }

        public void ReserveChanges()
        {
            var data = PlayerData.Instance.GetData<LocationData>();
            data.ReservedValue = data.CurrentValue;
        }

        public void ApplyChanges()
        {
            var data = PlayerData.Instance.GetData<LocationData>();
            data.ReservedValue = string.Empty;
            data.CurrentValue = string.Empty;
        }
    }
}
