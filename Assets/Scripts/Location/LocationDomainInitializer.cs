using Game.Core;
using UnityEngine;

namespace Game.Location
{
    public class LocationDomainInitializer : MonoBehaviour
    {
        private void Awake()
        {
            var data = PlayerData.Instance.GetData<LocationData>();
            if (data == null)
            {
                data = new LocationData();
                PlayerData.Instance.SetData(data);
            }
        }
    }
}
