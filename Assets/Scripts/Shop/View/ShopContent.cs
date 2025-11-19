using System.Collections.Generic;
using DanielLochner.Assets.SimpleScrollSnap;
using Game.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Shop
{
    public class ShopContent : MonoBehaviour
    {
        [SerializeReference] private ShopItem _itemPrefab;
        [SerializeReference] private Toggle _togglePrefab;
        [SerializeReference] private ToggleGroup _toggleGroup;
        [SerializeReference] private SimpleScrollSnap _scrollSnap;
        [SerializeReference] private ShopBundlesSO _shopData;

        private float _toggleWidth;

        void Awake()
        {
            _toggleWidth = ((RectTransform) _togglePrefab.transform).sizeDelta.x * (Screen.width / Constants.ScreenResolution.x);
        }

        void Start()
        {
            for (int index = 0; index < _shopData.Bundles.Count; index++)
            {
                Add(index);
            }
        }

        public void Add(int index)
        {
            Transform paginationTransform = _scrollSnap.Pagination.transform;
            Vector3 position = paginationTransform.position;
            Toggle toggle = Instantiate(_togglePrefab, position + new Vector3(_toggleWidth * (_scrollSnap.NumberOfPanels + 1), 0, 0), Quaternion.identity, paginationTransform);
            toggle.group = _toggleGroup;
            position -= new Vector3(_toggleWidth / 2f, 0, 0);
            _scrollSnap.Pagination.transform.position = position;

            _itemPrefab.gameObject.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            _scrollSnap.Add(_itemPrefab.gameObject, index);
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
    }
}
