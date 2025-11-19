using System;
using Game.Core;
using UnityEngine;

namespace Game.VIP
{
    public class VIPCostComponent : MonoBehaviour, ICost
    {
        private TimeSpan _cost;

        public bool CanAfford()
        {
            return PlayerData.Instance.VIPDuration.TotalSeconds - PlayerData.Instance.ReservedVIPDuration.TotalSeconds > _cost.TotalSeconds;
        }

        public void SetValue(string value)
        {
            var seconds = float.Parse(value);
            _cost = TimeSpan.FromSeconds(seconds);
        }

        public void ReserveChanges()
        {
            PlayerData.Instance.ReservedVIPDuration += _cost;
        }

        public void ApplyChanges()
        {
            PlayerData.Instance.VIPDuration -= _cost;
            PlayerData.Instance.ReservedVIPDuration -= _cost;
        }
    }
}
