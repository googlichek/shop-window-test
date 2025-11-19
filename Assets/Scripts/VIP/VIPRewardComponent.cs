using System;
using Game.Core;
using UnityEngine;

namespace Game.VIP
{
    public class VIPRewardComponent : MonoBehaviour, IReward
    {
        private TimeSpan _reward;

        public bool DoWant()
        {
            return true;
        }

        public void SetValue(string value)
        {
            var seconds = float.Parse(value);
            _reward = TimeSpan.FromSeconds(seconds);
        }

        public void ReserveChanges()
        {
        }

        public void ApplyChanges()
        {
            PlayerData.Instance.VIPDuration += _reward;
        }
    }
}
