using Game.Core;
using UnityEngine;

namespace Game.Location
{
    public class LocationDomainInitializer : MonoBehaviour
    {
        private void Awake()
        {
            var data = new LocationData();
            PlayerData.Instance.SetData(data);
        }
    }
}
