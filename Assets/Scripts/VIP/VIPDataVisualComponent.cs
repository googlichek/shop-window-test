using System;
using System.Globalization;
using Game.Core;
using UnityEngine;

namespace Game.VIP
{
    public class VIPDataDataVisualComponent : BundleDataVisualComponent
    {
        [Space]

        [SerializeField] private float CheatValue = 30.0f;

        private VIPData _data;

        void Start()
        {
            _data = PlayerData.Instance.GetData<VIPData>();
        }

        void Update()
        {
            var valueString = _data.CurrentValue.ToString(CultureInfo.InvariantCulture.ToString());
            ValueText.SetText(valueString);
        }

        protected override void OnAddResourceButtonClick()
        {
            var timeSpan = TimeSpan.FromSeconds(CheatValue);
            _data.CurrentValue += timeSpan;
        }
    }
}
