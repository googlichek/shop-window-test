using System;
using System.Collections;
using System.Collections.Generic;
using Game.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Shop
{
    public class ShopItemComponent : MonoBehaviour
    {
        [SerializeReference] private TextMeshProUGUI _descriptionText;
        [SerializeReference] private TextMeshProUGUI _buyButtonText;

        [Space]

        [SerializeReference] private Button _previewButton;
        [SerializeReference] private Button _buyButton;

        [Space]

        [SerializeField] [Range(0.01f, 10.0f)] private float _purchaseProcessingDelay;

        [Space]

        [SerializeField] private string _purchaseString = "Purchase";
        [SerializeField] private string _processingString = "Processing";

        private List<ICost> _costComponents;
        private List<IReward> _rewardComponents;

        private int _cardIndex;

        bool isPurchasing = false;
        bool hasSceneLoaded = false;

        void Awake()
        {
            _buyButton.onClick.AddListener(OnBuyButtonClick);
            _buyButtonText.SetText(_purchaseString);

            _previewButton.onClick.AddListener(OnPreviewButtonClick);

            SceneManager.sceneLoaded += HandleSceneLoaded;
            HandleSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        void Update()
        {
            if (isPurchasing)
            {
                return;
            }

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

            foreach (var rewardComponent in _rewardComponents)
            {
                if (rewardComponent.DoWant())
                {
                    continue;
                }

                isButtonInteractable = false;
                break;
            }

            if (_buyButton.interactable != isButtonInteractable)
            {
                _buyButton.interactable = isButtonInteractable;
            }
        }

        void OnDestroy()
        {
            _buyButton.onClick.RemoveListener(OnBuyButtonClick);
            _previewButton.onClick.RemoveListener(OnPreviewButtonClick);
            SceneManager.sceneLoaded -= HandleSceneLoaded;
        }

        public void Setup(int cardIndex, string description, List<ICost> costComponents, List<IReward> rewardComponents)
        {
            _cardIndex = cardIndex;
            _descriptionText.SetText(description);
            _costComponents = costComponents;
            _rewardComponents = rewardComponents;
        }

        private void OnBuyButtonClick()
        {
            isPurchasing = true;

            _buyButton.interactable = false;

            StartCoroutine(BuyBundleCoroutine());
        }

        private void OnPreviewButtonClick()
        {
            PlayerData.Instance.CloseUpCardIndex = _cardIndex;

            int cardCloseUpSceneIndex = Convert.ToInt32(Scenes.CardCloseUp);
            SceneManager.LoadScene(cardCloseUpSceneIndex);
        }

        private IEnumerator BuyBundleCoroutine()
        {
            _buyButtonText.SetText(_processingString);

            foreach (var costComponent in _costComponents)
            {
                costComponent.ReserveChanges();
            }

            foreach (var rewardComponent in _rewardComponents)
            {
                rewardComponent.ReserveChanges();
            }

            yield return new WaitForSeconds(_purchaseProcessingDelay);

            foreach (var costComponent in _costComponents)
            {
                costComponent.ApplyChanges();
            }

            foreach (var rewardComponent in _rewardComponents)
            {
                rewardComponent.ApplyChanges();
            }

            isPurchasing = false;
            _buyButtonText.SetText(_purchaseString);
        }

        private void HandleSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (hasSceneLoaded)
            {
                return;
            }

            hasSceneLoaded = true;

            int closeUpSceneIndex = Convert.ToInt32(Scenes.CardCloseUp);
            _previewButton.gameObject.SetActive(scene.buildIndex != closeUpSceneIndex);
        }
    }
}
