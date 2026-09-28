using System;
using _Project.Develop.Gameplay.Ship;
using _Project.Develop.Wind;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Ui
{
    public class UiController : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Text _speedText = default;

        [SerializeField] private Toggle _manualSetWindDirectionToggle = default;
        [SerializeField] private Slider _windDirectionSlider = default;

        [SerializeField] private WindSystem _windSystem = default;
        [SerializeField] private ShipController _shipController = default;

        private void Awake()
        {
            _manualSetWindDirectionToggle.isOn = _windSystem.ManualWindDirectionSet;
            _windDirectionSlider.value = _windSystem.WindDegrees;
        }

        private void OnEnable()
        {
            _manualSetWindDirectionToggle.onValueChanged.AddListener(OnToggleManualSetDirectionWindChanged);
            _windDirectionSlider.onValueChanged.AddListener(OnWindDirectionChanged);
        }

        private void OnDisable()
        {
            _manualSetWindDirectionToggle.onValueChanged.RemoveListener(OnToggleManualSetDirectionWindChanged);
            _windDirectionSlider.onValueChanged.RemoveListener(OnWindDirectionChanged);
        }

        private void Update()
            => RedrawSpeed();

        private void OnWindDirectionChanged(float newValue)
            => _windSystem.SetDegrees(newValue);

        private void OnToggleManualSetDirectionWindChanged(bool newValue)
            => _windSystem.ToggleManualWindDirectionSet(newValue);

        private void RedrawSpeed()
            => _speedText.text = $"{_shipController.GetSpeed : 0.0}";
    }
}
