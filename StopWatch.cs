using System;

//Programmer Name: Stephanie Goedde

namespace SortingAlgorithms
{
    class StopWatch
    {
        private DateTime start;
        private DateTime stop;
        private bool running = false;

        public void Start()
        {
            this.start = DateTime.Now;
            this.running = true;
        }

        public void Stop()
        {
            this.stop = DateTime.Now;
            this.running = false;
        }


        // elaspsed time in milliseconds
        public double GetElapsedTime()
        {
            TimeSpan interval;

            if (running)
                interval = DateTime.Now - start;
            else
                interval = stop - start;

            return interval.TotalMilliseconds;
        }


        // elaspsed time in seconds
        public double GetElapsedTimeSecs()
        {
            TimeSpan interval;

            if (running)
                interval = DateTime.Now - start;
            else
                interval = stop - start;

            return interval.TotalSeconds;
        }
    }
}
