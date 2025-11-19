using System;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Shop
{
    public class ShopItemComponent : MonoBehaviour
    {
        [SerializeReference] private Button _button;

        private List<ICost> _costComponents;
        private List<IReward> _rewardComponents;

        void Awake()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        void Update()
        {
            bool isButtonInteractable = true;
            foreach (var costComponent in _costComponents)
            {
                if (costComponent.CanAfford())
                {
                    continue;
                }

                isButtonInteractable = false;
                break;
            }

            if (_button.interactable != isButtonInteractable)
            {
                _button.interactable = isButtonInteractable;
            }
        }

        void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        public void Setup(List<ICost> costComponents, List<IReward> rewardComponents)
        {
            _costComponents = costComponents;
            _rewardComponents = rewardComponents;
        }

        private void OnButtonClick()
        {
            if (!_button.interactable)
            {
                return;
            }

            foreach (var costComponent in _costComponents)
            {
                costComponent.Apply();
            }

            foreach (var rewardComponent in _rewardComponents)
            {
                rewardComponent.Apply();
            }
        }
    }
}
