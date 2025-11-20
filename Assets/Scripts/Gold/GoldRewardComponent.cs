using Game.Core;
using UnityEngine;

namespace Game.Gold
{
    public class GoldRewardComponent : MonoBehaviour, IReward
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

        public void ReserveChanges()
        {
        }

        public void ApplyChanges()
        {
            var data = PlayerData.Instance.GetData<GoldData>();
            data.CurrentValue += _reward;
        }
    }
}
