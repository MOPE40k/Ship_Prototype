using UnityEngine;

namespace _Project.Develop.InputHandle
{
    public class InputHandler
    {
        // Consts
        private const float NegativeValue = -1.0f;
        private const float PositiveValue = 1.0f;
        private const float NeutralValue = 0.0f;

        public float GetAxis(KeyCode negative, KeyCode positive)
        {
            if (Input.GetKey(negative))
                return NegativeValue;
            else if (Input.GetKey(positive))
                return PositiveValue;
            else
                return NeutralValue;
        }
    }
}