using System.Globalization;
using Game.Core;
using UnityEngine;

namespace Game.Gold
{
    public class GoldDataVisualComponent : BundleDataVisualComponent
    {
        [Space]

        [SerializeField] private float CheatValue = 100.0f;

        private GoldData _data;

        void Start()
        {
            _data = PlayerData.Instance.GetData<GoldData>();
        }

        void Update()
        {
            var valueString = _data.CurrentValue.ToString(CultureInfo.InvariantCulture);
            ValueText.SetText(valueString);
        }

        protected override void OnAddResourceButtonClick()
        {
            _data.CurrentValue += CheatValue;
        }
    }
}
