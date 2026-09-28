using UnityEngine;

namespace _Project.Develop.Utils.TransformUtils
{
    public class DirectionRotator : IRotatable
    {
        // Settings
        private readonly Transform _transform = null;
        private readonly float _speed = 0f;
        private readonly Space _relativeSpace = Space.Self;

        // Runtime
        private Vector3 _currentDirection = Vector3.zero;

        public DirectionRotator(Transform transform, float speed, Space relativeSpace = Space.Self)
        {
            _transform = transform;
            _speed = (speed <= 0) ? 0 : speed;
            _relativeSpace = relativeSpace;
        }

        public void SetDirection(Vector3 direction)
            => _currentDirection = direction;

        public void UpdateTick(float timeDelta)
        {
            if (_currentDirection == Vector3.zero)
                return;

            float maxDegreesDelta = _speed * timeDelta;

            if (_relativeSpace == Space.Self)
                LocalRotation(maxDegreesDelta);
            else
                WorldRotation(maxDegreesDelta);
        }

        private void LocalRotation(float degreesDelta)
        {
            _transform.localRotation = Quaternion.RotateTowards(
                _transform.localRotation,
                Quaternion.Euler(_currentDirection),
                degreesDelta);
        }

        private void WorldRotation(float degreesDelta)
        {
            _transform.rotation = Quaternion.RotateTowards(
                _transform.rotation,
                Quaternion.LookRotation(_currentDirection),
                degreesDelta);
        }
    }
}