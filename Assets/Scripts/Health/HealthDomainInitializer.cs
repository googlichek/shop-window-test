using Game.Core;
using UnityEngine;

namespace Game.Health
{
    public class HealthDomainInitializer : MonoBehaviour
    {
        private void Awake()
        {
            var data = PlayerData.Instance.GetData<HealthData>();
            if (data == null)
            {
                data = new HealthData();
                PlayerData.Instance.SetData(data);
            }
        }
    }
}
