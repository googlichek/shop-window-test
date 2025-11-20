using System.Globalization;
using Game.Core;
using UnityEngine;

namespace Game.Health
{
    public class HealthDataVisualComponent : BundleDataVisualComponent
    {
        [Space]

        [SerializeField] private float CheatValue = 10.0f;

        private HealthData _data;

        void Start()
        {
            _data = PlayerData.Instance.GetData<HealthData>();
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
