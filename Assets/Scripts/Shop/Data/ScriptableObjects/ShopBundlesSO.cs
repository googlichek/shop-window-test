using System.Collections.Generic;
using Game.Core;
using UnityEngine;

namespace Game.Shop
{
    [CreateAssetMenu(fileName = "ShopBundlesSO", menuName = "Scriptable Objects/Shop Bundles")]
    public class ShopBundlesSO : ScriptableObject
    {
        public List<BundleItemSO> Bundles;
    }
}
