using _Project.Develop.Gameplay.Seals;
using _Project.Develop.Utils;
using _Project.Develop.Utils.TransformUtils;
using _Project.Develop.Wind;
using UnityEngine;

namespace _Project.Develop.Gameplay.Ship
{
    public class ShipController : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField, Min(0.1f)] private float _rotationSpeed = 1f;
        [SerializeField, Min(0f)] private float _moveSpeed = 0f;

        [Space]
        [Header("References:")]
        [SerializeField] private SailController sailController = null;
        [SerializeField] private WindSystem _windSystem = null;

        // References
        private DirectionMover _mover = null;
        private IRotatable _rotator = null;

        // Runtime
        public float GetSpeed => CalculateSpeed();

        private void Awake()
        {
            _mover = new DirectionMover(this.transform, _moveSpeed);
            _rotator = new AxisRotator(this.transform, _rotationSpeed);
        }

        private void Update()
            => Move(Time.deltaTime);

        public void Rotate(float input)
        {
            if (input == 0)
                return;

            _rotator.SetDirection(Vector3.up * input);
            _rotator.UpdateTick(Time.deltaTime);
        }

        private void Move(float deltaTime)
        {
            float speed = CalculateSpeed();

            Vector3 newDirection = transform.forward * speed;

            _mover.SetDirection(newDirection);
            _mover.UpdateTick(deltaTime);
        }

        private float CalculateSpeed()
        {
            float shipWindDot = VectorUtils.GetNormalizedDot(transform.forward, _windSystem.WindDirection);
            float shipSealsDot = VectorUtils.GetNormalizedDot(transform.forward, sailController.SealForwardDirection);
            
            return shipWindDot * shipSealsDot * sailController.CurrentSealsForce;
        }
    }
}