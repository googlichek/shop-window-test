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
        //     var goldValueString = PlayerData.Instance.GoldData.CurrentValue.ToString(CultureInfo.InvariantCulture);
        //     _goldValueText.SetText(goldValueString);
        //
        //     var healthValueString = PlayerData.Instance.HealthData.CurrentValue.ToString(CultureInfo.InvariantCulture);
        //     _healthValueText.SetText(healthValueString);
        //
        //     var locationValueString = PlayerData.Instance.LocationData.CurrentValue;
        //     _locationValueText.SetText(locationValueString);
        //
        //     var vipValueString = PlayerData.Instance.VIPDurationData.CurrentValue.ToString(CultureInfo.InvariantCulture.ToString());
        //     _VIPValueText.SetText(vipValueString);
        }
    }
}
