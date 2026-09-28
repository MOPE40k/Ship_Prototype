namespace _Project.Develop.Utils
{
    public class Timer
    {
        // Runtime
        public float Time { get; private set; } = 0f;

        public Timer()
            => ResetTime();

        public void ResetTime()
            => Time = 0f;

        public void IncrementTimerBy(float delta)
        {
            if (delta <= 0)
                return;

            Time += delta;
        }

        public void DecrementTimerBy(float delta)
        {
            if (delta <= 0)
                return;

            Time -= delta;

            if (Time <= 0)
                ResetTime();
        }
    }
}