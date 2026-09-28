using UnityEngine;

namespace _Project.Develop.Utils.TransformUtils
{
    public class AxisRotator : IRotatable
    {
        // Settings
        private readonly Transform _transform = null;
        private readonly float _speed = 0f;

        // Runtime
        private Vector3 _currentDirection = Vector3.zero;

        public AxisRotator(Transform transform, float speed)
        {
            _transform = transform;
            _speed = (speed <= 0f) ? 0f : speed;
        }

        public void SetDirection(Vector3 direction)
            => _currentDirection = direction;

        public void UpdateTick(float timeDelta)
        {
            if (_currentDirection == Vector3.zero)
                return;

            Rotate(timeDelta);
        }

        private void Rotate(float delta)
        {
            Vector3 stepRotation = _currentDirection * delta;

            if (_speed > 0)
                stepRotation *= _speed;

            _transform.Rotate(stepRotation);
        }
    }
}