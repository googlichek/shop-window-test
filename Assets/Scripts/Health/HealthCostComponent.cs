using Game.Core;
using UnityEngine;

namespace Game.Health
{
    public class HealthCostComponent : MonoBehaviour, ICost
    {
        private float _cost;

        public bool CanAfford()
        {
            return PlayerData.Instance.Health - PlayerData.Instance.ReservedHealth > _cost;
        }

        public void SetValue(string value)
        {
            _cost = float.Parse(value);
        }

        public void ReserveChanges()
        {
            PlayerData.Instance.ReservedHealth += _cost;
        }

        public void ApplyChanges()
        {
            PlayerData.Instance.Health -= _cost;
            PlayerData.Instance.ReservedHealth -= _cost;
        }
    }
}
