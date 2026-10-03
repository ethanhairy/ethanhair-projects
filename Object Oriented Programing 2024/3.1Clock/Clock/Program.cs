using System;
using System.Diagnostics.Metrics;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            int i;

            for (i = 0; i < 86400; i++) //86400sec = 24hrs
            {
                Thread.Sleep(10); //waits 10 milliseconds before ticking
                Console.Clear();
                clock.Tick();
                Console.WriteLine(clock.CurrentTime());
            }
        }
    }
}