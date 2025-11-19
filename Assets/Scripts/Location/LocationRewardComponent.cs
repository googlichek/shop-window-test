using Game.Core;
using UnityEngine;

namespace Game.Location
{
    public class LocationRewardComponent : MonoBehaviour, IReward
    {
        private string _reward;

        public void SetValue(string value)
        {
            _reward = value;
        }

        public void Apply()
        {
            PlayerData.Instance.Location = _reward;
        }
    }
}
