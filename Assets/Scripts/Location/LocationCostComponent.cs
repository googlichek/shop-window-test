using Game.Core;
using UnityEngine;

namespace Game.Location
{
    public class LocationCostComponent : MonoBehaviour, ICost
    {
        private string _cost;

        public bool CanAfford()
        {
            return PlayerData.Instance.Location.Equals(_cost);
        }

        public void SetValue(string value)
        {
            _cost = value;
        }

        public void Apply()
        {
            PlayerData.Instance.Location = string.Empty;
        }
    }
}
