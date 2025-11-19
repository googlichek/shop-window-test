using Game.Core;
using UnityEngine;

namespace Game.Location
{
    public class LocationCostComponent : MonoBehaviour, ICost
    {
        private string _cost;

        public bool CanAfford()
        {
            return PlayerData.Instance.Location.Equals(_cost) && string.IsNullOrEmpty(PlayerData.Instance.ReservedLocation);
        }

        public void SetValue(string value)
        {
            _cost = value;
        }

        public void ReserveChanges()
        {
            PlayerData.Instance.ReservedLocation = PlayerData.Instance.Location;
        }

        public void ApplyChanges()
        {
            PlayerData.Instance.ReservedLocation = string.Empty;
            PlayerData.Instance.Location = string.Empty;
        }
    }
}
