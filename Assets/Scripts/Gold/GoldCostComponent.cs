using Game.Core;
using UnityEngine;

namespace Game.Gold
{
    public class GoldCostComponent : MonoBehaviour, ICost
    {
        private float _cost;

        public bool CanAfford()
        {
            return PlayerData.Instance.Gold >= _cost;
        }

        public void SetValue(string value)
        {
            _cost = float.Parse(value);
        }

        public void Apply()
        {
            PlayerData.Instance.Gold -= _cost;
        }
    }
}
