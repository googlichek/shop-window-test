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
            return PlayerData.Instance.VIPDuration.TotalSeconds > _cost.TotalSeconds;
        }

        public void SetValue(string value)
        {
            var seconds = float.Parse(value);
            _cost = TimeSpan.FromSeconds(seconds);
        }

        public void Apply()
        {
            PlayerData.Instance.VIPDuration -= _cost;
        }
    }
}
