using Game.Core;
using UnityEngine;

namespace Game.Location
{
    public class LocationDataVisualComponent : BundleDataVisualComponent
    {
        [Space]

        [SerializeField] private string CheatValue = "Forest";

        private LocationData _data;

        void Start()
        {
            _data = PlayerData.Instance.GetData<LocationData>();
        }

        void Update()
        {
            var valueString = _data.CurrentValue;
            ValueText.SetText(valueString);
        }

        protected override void OnAddResourceButtonClick()
        {
            if (!string.IsNullOrEmpty(_data.CurrentValue))
            {
                return;
            }

            _data.CurrentValue = CheatValue;
        }
    }
}
