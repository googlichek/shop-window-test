using Game.Core;
using UnityEngine;

namespace Game.Gold
{
    public class GoldCostComponent : MonoBehaviour, ICost
    {
        private float _cost;

        public bool CanAfford()
        {
            var data = PlayerData.Instance.GetData<GoldData>();
            return data.CurrentValue - data.ReservedValue >= _cost;
        }

        public void SetValue(string value)
        {
            _cost = float.Parse(value);
        }

        public void ReserveChanges()
        {
            var data = PlayerData.Instance.GetData<GoldData>();
            data.ReservedValue += _cost;
        }

        public void ApplyChanges()
        {
            var data = PlayerData.Instance.GetData<GoldData>();
            data.CurrentValue -= _cost;
            data.ReservedValue -= _cost;
        }
    }
}
