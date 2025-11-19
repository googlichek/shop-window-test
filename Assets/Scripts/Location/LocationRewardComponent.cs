using Game.Core;
using UnityEngine;

namespace Game.Location
{
    public class LocationRewardComponent : MonoBehaviour, IReward
    {
        private string _reward;

        public bool DoWant()
        {
            return string.IsNullOrEmpty(PlayerData.Instance.Location) && string.IsNullOrEmpty(PlayerData.Instance.ReservedLocation);
        }

        public void SetValue(string value)
        {
            _reward = value;
        }

        public void ReserveChanges()
        {
            PlayerData.Instance.ReservedLocation = _reward;
        }

        public void ApplyChanges()
        {
            PlayerData.Instance.Location = _reward;
            PlayerData.Instance.ReservedLocation = string.Empty;
        }
    }
}
