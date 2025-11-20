using Game.Core;
using UnityEngine;

namespace Game.Gold
{
    public class GoldDomainInitializer : MonoBehaviour
    {
        private void Awake()
        {
            var data = new GoldData();
            PlayerData.Instance.SetData(data);
        }
    }
}
