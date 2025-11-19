using System.Collections.Generic;
using Game.Core;
using UnityEngine;

namespace Game.Shop
{
    public class ShopItemComponent : MonoBehaviour
    {
        private List<ICost> _costComponents;
        private List<IReward> _rewardComponents;

        public void Setup(List<ICost> costComponents, List<IReward> rewardComponents)
        {
            _costComponents = costComponents;
            _rewardComponents = rewardComponents;
        }
    }
}
