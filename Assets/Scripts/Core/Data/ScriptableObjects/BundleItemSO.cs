using UnityEngine;

namespace Game.Core
{
    [CreateAssetMenu(fileName = "BundleItemSO", menuName = "Scriptable Objects/Bundle Item")]
    public class BundleItemSO : ScriptableObject
    {
        public string Description;

        public string CostValue;

        public string RewardValue;
    }
}
