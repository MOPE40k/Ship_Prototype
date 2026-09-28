using System;
using _Project.Develop.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Develop.Wind
{
    public class WindSystem : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField, Min(0f)] private float _switchWindDirectionInterval = 10f;

        [field: Space] 
        [field: Header("Manual Set Direction Settings:")]
        [field: SerializeField] public bool ManualWindDirectionSet { get; private set; } = default;
        [field: SerializeField, Range(0f, 360f)] public float WindDegrees { get; private set; } = default;

        // References
        private Timer _timer = default;

        // Runtime
        public Vector3 WindDirection { get; private set; } = default;

        private void Awake()
        {
            _timer = new Timer();
        }

        private void Start()
        {
            if (ManualWindDirectionSet)
                SetDirection(WindDegrees);
            else
                RandomHorizontalDirection();
        }

        private void Update()
        {
            if (ManualWindDirectionSet)
            {
                SetDirection(WindDegrees);
            }
            else
            {
                if (_timer.Time >= _switchWindDirectionInterval)
                {
                    RandomHorizontalDirection();

                    _timer.DecrementTimerBy(_switchWindDirectionInterval);
                }

                _timer.IncrementTimerBy(Time.deltaTime);
            }
        }

        public void ToggleManualWindDirectionSet(bool state)
        {
            ManualWindDirectionSet = state;

            if (!state)
                RandomHorizontalDirection();
        }

        public void SetDegrees(float degrees)
        {
            if (!ManualWindDirectionSet)
                return;
            
            WindDegrees = degrees;
        }

        private void SetDirection(float degrees)
        {
            var radians = (WindDegrees + 180f) * Mathf.Deg2Rad;
            WindDirection = new Vector3(Mathf.Sin(radians), 0f, Mathf.Cos(radians));
        }

        private void RandomHorizontalDirection()
        {
            WindDegrees = Random.Range(0f, 360f);
            SetDirection(WindDegrees);
        }
    }
}