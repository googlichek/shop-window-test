using System.Globalization;
using Game.Core;
using TMPro;
using UnityEngine;

namespace Game.Shop
{
    public class PlayerDataBarComponent : MonoBehaviour
    {
        [SerializeReference] private TextMeshProUGUI _goldValueText;
        [SerializeReference] private TextMeshProUGUI _healthValueText;
        [SerializeReference] private TextMeshProUGUI _locationValueText;
        [SerializeReference] private TextMeshProUGUI _VIPValueText;

        void Update()
        {
            var goldValueString = PlayerData.Instance.Gold.ToString(CultureInfo.InvariantCulture);
            _goldValueText.SetText(goldValueString);

            var healthValueString = PlayerData.Instance.Health.ToString(CultureInfo.InvariantCulture);
            _healthValueText.SetText(healthValueString);

            var locationValueString = PlayerData.Instance.Location;
            _locationValueText.SetText(locationValueString);

            var vipValueString = PlayerData.Instance.VIPDuration.ToString(CultureInfo.InvariantCulture.ToString());
            _VIPValueText.SetText(vipValueString);
        }
    }
}
