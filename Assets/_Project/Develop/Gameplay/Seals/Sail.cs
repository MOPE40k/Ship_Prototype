using UnityEngine;

namespace _Project.Develop.Gameplay.Seals
{
    public class Sail : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField, Min(0f)] private float _force = 1f;

        // Runtime
        public float Force => _force;
    }
}