using _Project.Develop.Utils.TransformUtils;
using _Project.Develop.Wind;
using UnityEngine;

namespace _Project.Develop.Gameplay.Ship
{
    public class WindArrow : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField, Min(0.1f)] private float _rotationSpeed = 1f;

        [Space]
        [Header("References:")]
        [SerializeField] private WindSystem _windSystem = null;

        // References
        private IRotatable _rotator = null;

        private void Awake()
            => _rotator = new DirectionRotator(this.transform, _rotationSpeed, Space.World);

        private void Update()
        {
            _rotator.SetDirection(_windSystem.WindDirection.normalized);
            _rotator.UpdateTick(Time.deltaTime);
        }
    }
}