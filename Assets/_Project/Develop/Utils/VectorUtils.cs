using UnityEngine;

namespace _Project.Develop.Utils
{
    public static class VectorUtils
    {
        public static float GetNormalizedDot(Vector3 a, Vector3 b)
            => Vector3.Dot(a.normalized, b.normalized);
    }
}