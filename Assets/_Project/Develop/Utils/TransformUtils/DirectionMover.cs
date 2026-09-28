using UnityEngine;

namespace _Project.Develop.Utils.TransformUtils
{
    public class DirectionMover
    {
        // Settings
        private readonly Transform _transform = null;
        private readonly float _speed = 0f;

        // Runtime
        private Vector3 _currentDirection = Vector3.zero;

        public DirectionMover(Transform transform, float speed)
        {
            _transform = transform;
            _speed = (speed <= 0) ? 0 : speed;
        }

        public void SetDirection(Vector3 direction)
            => _currentDirection = direction;

        public void UpdateTick(float timeDelta)
        {
            if (_currentDirection == Vector3.zero)
                return;

            Move(timeDelta);
        }

        private void Move(float delta)
        {
            Vector3 stepPosition = _currentDirection * delta;

            if (_speed > 0)
                stepPosition *= _speed;

            _transform.position += stepPosition;
        }
    }
}