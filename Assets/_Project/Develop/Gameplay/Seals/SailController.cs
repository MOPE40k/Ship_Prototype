using _Project.Develop.Utils;
using _Project.Develop.Utils.TransformUtils;
using _Project.Develop.Wind;
using UnityEngine;

namespace _Project.Develop.Gameplay.Seals
{
    public class SailController : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField] private float _maxSealRotation = 90f;
        [SerializeField] private float _rotationSpeed = 1f;

        [Space]
        [Header("References:")]
        [SerializeField] private Sail[] _seals = null;
        [SerializeField] private WindSystem _windSystem = null;

        // References
        private IRotatable[] _rotators = null;

        // Runtime
        public float CurrentSealsForce => CalculateSealsForce();
        public Vector3 SealForwardDirection => _seals[0].transform.forward;

        private void Awake()
            => SealsInit();

        public void SealsRotate(float input)
        {
            if (input == 0)
                return;

            foreach (DirectionRotator rotator in _rotators)
            {
                rotator.SetDirection(Vector3.up * input * _maxSealRotation);
                rotator.UpdateTick(Time.deltaTime);
            }
        }

        private void SealsInit()
        {
            if (_seals.Length <= 0)
                return;

            _rotators = new DirectionRotator[_seals.Length];

            for (int i = 0; i < _seals.Length; i++)
                _rotators[i] = new DirectionRotator(_seals[i].transform, _rotationSpeed, Space.Self);
        }


        private float CalculateSealsForce()
        {
            float result = 0f;

            foreach (Sail seal in _seals)
            {
                float sealWindDot = VectorUtils.GetNormalizedDot(seal.transform.forward, _windSystem.WindDirection);

                if (sealWindDot > 0f)
                    result += sealWindDot * seal.Force;
            }

            return result;
        }
    }
}