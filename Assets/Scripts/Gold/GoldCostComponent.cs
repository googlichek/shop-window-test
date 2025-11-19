using Game.Core;
using UnityEngine;

namespace Game.Gold
{
    public class GoldCostComponent : MonoBehaviour, ICost
    {
        private float _cost;

        public bool CanAfford()
        {
            return PlayerData.Instance.Gold - PlayerData.Instance.ReservedGold >= _cost;
        }

        public void SetValue(string value)
        {
            _cost = float.Parse(value);
        }

        public void ReserveChanges()
        {
            PlayerData.Instance.ReservedGold += _cost;
        }

        public void ApplyChanges()
        {
            PlayerData.Instance.Gold -= _cost;
            PlayerData.Instance.ReservedGold -= _cost;
        }
    }
}
