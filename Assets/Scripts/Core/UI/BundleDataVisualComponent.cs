using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Core
{
    public abstract class BundleDataVisualComponent : MonoBehaviour
    {
        [SerializeReference] private Button _addResourceButton;
        [SerializeReference] protected TextMeshProUGUI ValueText;

        void Awake()
        {
            _addResourceButton.onClick.AddListener(OnAddResourceButtonClick);
        }

        void OnDestroy()
        {
            _addResourceButton.onClick.RemoveListener(OnAddResourceButtonClick);
        }

        protected virtual void OnAddResourceButtonClick()
        {
        }
    }
}
