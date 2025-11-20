using Game.Core;
using UnityEngine;

namespace Game.VIP
{
    public class VIPDomainInitializer : MonoBehaviour
    {
        private void Awake()
        {
            var data = PlayerData.Instance.GetData<VIPData>();
            if (data == null)
            {
                data = new VIPData();
                PlayerData.Instance.SetData(data);
            }
        }
    }
}
