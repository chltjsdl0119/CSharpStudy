using System;

namespace HorseRacing
{
    public class Horse
    {
        public string name;
        public double distance;

        private Random random = new Random();
        public void Run()
        {
            distance += (1.0f + random.NextDouble()) * 10.0f;
        }
    }
}