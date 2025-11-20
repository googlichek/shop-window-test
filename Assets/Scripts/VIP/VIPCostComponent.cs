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
            var data = PlayerData.Instance.GetData<VIPData>();
            return data.CurrentValue.TotalSeconds - data.ReservedValue.TotalSeconds > _cost.TotalSeconds;
        }

        public void SetValue(string value)
        {
            var seconds = float.Parse(value);
            _cost = TimeSpan.FromSeconds(seconds);
        }

        public void ReserveChanges()
        {
            var data = PlayerData.Instance.GetData<VIPData>();
            data.ReservedValue += _cost;
        }

        public void ApplyChanges()
        {
            var data = PlayerData.Instance.GetData<VIPData>();
            data.CurrentValue -= _cost;
            data.ReservedValue -= _cost;
        }
    }
}
