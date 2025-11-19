using Game.Core;
using UnityEngine;

namespace Game.Health
{
    public class HealthRewardComponent : MonoBehaviour, IReward
    {
        private float _reward;

        public bool DoWant()
        {
            return true;
        }

        public void SetValue(string value)
        {
            _reward = float.Parse(value);
        }

        public void Apply()
        {
            PlayerData.Instance.Health += _reward;
        }
    }
}
