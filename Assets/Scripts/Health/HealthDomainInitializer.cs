using Game.Core;
using UnityEngine;

namespace Game.Health
{
    public class HealthDomainInitializer : MonoBehaviour
    {
        private void Awake()
        {
            var data = new HealthData();
            PlayerData.Instance.SetData(data);
        }
    }
}
