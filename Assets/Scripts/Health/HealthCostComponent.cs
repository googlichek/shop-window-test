using Game.Core;
using UnityEngine;

namespace Game.Health
{
    public class HealthCostComponent : MonoBehaviour, ICost
    {
        private float _cost;

        public bool CanAfford()
        {
            var data = PlayerData.Instance.GetData<HealthData>();
            return data.CurrentValue - data.ReservedValue > _cost;
        }

        public void SetValue(string value)
        {
            _cost = float.Parse(value);
        }

        public void ReserveChanges()
        {
            var data = PlayerData.Instance.GetData<HealthData>();
            data.ReservedValue += _cost;
        }

        public void ApplyChanges()
        {
            var data = PlayerData.Instance.GetData<HealthData>();
            data.CurrentValue -= _cost;
            data.ReservedValue -= _cost;
        }
    }
}
