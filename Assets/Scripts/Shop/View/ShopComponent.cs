using System;
using DanielLochner.Assets.SimpleScrollSnap;
using Game.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game.Shop
{
    public class ShopComponent : MonoBehaviour
    {
        [SerializeReference] private GameObject _itemPrefab;
        [SerializeReference] private Toggle _togglePrefab;

        [Space]

        [SerializeReference] private ToggleGroup _toggleGroup;
        [SerializeReference] private SimpleScrollSnap _scrollSnap;

        [Space]

        [SerializeReference] private ShopBundlesSO _shopData;

        [Space]

        [SerializeReference] private Button _backButton;
        [SerializeReference] private Button _exitButton;

        private float _toggleWidth;

        bool hasSceneLoaded = false;

        void Awake()
        {
            _toggleWidth = ((RectTransform) _togglePrefab.transform).sizeDelta.x * (Screen.width / Constants.ScreenResolution.x);

            _backButton.onClick.AddListener(OnBackButtonClick);
            _exitButton.onClick.AddListener(OnExitButtonClick);

            SceneManager.sceneLoaded += HandleSceneLoaded;
            HandleSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        void OnDestroy()
        {
            _backButton.onClick.RemoveListener(OnBackButtonClick);
            _exitButton.onClick.RemoveListener(OnExitButtonClick);

            SceneManager.sceneLoaded -= HandleSceneLoaded;
        }

        public void Add(int index)
        {
            var paginationTransform = _scrollSnap.Pagination.transform;
            var position = paginationTransform.position;
            var toggle = Instantiate(_togglePrefab, position + new Vector3(_toggleWidth * (_scrollSnap.NumberOfPanels + 1), 0, 0), Quaternion.identity, paginationTransform);
            toggle.group = _toggleGroup;
            position -= new Vector3(_toggleWidth / 2f, 0, 0);
            _scrollSnap.Pagination.transform.position = position;

            var colorR = PlayerData.Instance.R * (1.0f + index) % 1.0f;
            var colorG = PlayerData.Instance.G * (1.0f + index) % 1.0f;
            var colorB = PlayerData.Instance.B * (1.0f + index) % 1.0f;

            var item = _scrollSnap.Add(_itemPrefab, index);
            item.GetComponent<Image>().color = new Color(colorR, colorG, colorB);

            var bundleItem = _shopData.Bundles[index];
            var costComponents = bundleItem.AddCostComponentsToGameObject(item.gameObject);
            var rewardComponents = bundleItem.AddRewardComponentsToGameObject(item.gameObject);
            var shopItemComponent = item.GetComponent<ShopItemComponent>();
            shopItemComponent.Setup(index, bundleItem.Description, costComponents, rewardComponents);
        }

        public void Remove(int index)
        {
            if (_scrollSnap.NumberOfPanels > 0)
            {
                DestroyImmediate(_scrollSnap.Pagination.transform.GetChild(_scrollSnap.NumberOfPanels - 1).gameObject);
                _scrollSnap.Pagination.transform.position += new Vector3(_toggleWidth / 2f, 0, 0);

                _scrollSnap.Remove(index);
            }
        }

        private void OnBackButtonClick()
        {
            int shopSceneIndex = Convert.ToInt32(Scenes.Shop);
            SceneManager.LoadScene(shopSceneIndex);
        }

        private void OnExitButtonClick()
        {
            Application.Quit();
        }

        private void HandleSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (hasSceneLoaded)
            {
                return;
            }

            hasSceneLoaded = true;

            int shopSceneIndex = Convert.ToInt32(Scenes.Shop);
            int cardCloseUpSceneIndex = Convert.ToInt32(Scenes.CardCloseUp);

            if (scene.buildIndex == shopSceneIndex)
            {
                _backButton.gameObject.SetActive(false);

                for (int index = 0; index < _shopData.Bundles.Count; index++)
                {
                    Add(index);
                }
            }

            if (scene.buildIndex == cardCloseUpSceneIndex)
            {
                _toggleGroup.gameObject.SetActive(false);
                _exitButton.gameObject.SetActive(false);

                Add(PlayerData.Instance.CloseUpCardIndex);
            }
        }
    }
}
