using System;
using System.Diagnostics.Metrics;

namespace Clock
{
    public class Clock
    {
        public Counter _second;
        public Counter _minute;
        public Counter _hour;

        public Clock()
        {
            _second = new Counter("second");
            _minute = new Counter("minute");
            _hour = new Counter("hour");
        }

        public void Tick()
        {
            _second.Increment();

            if (_second.Tick > 59)
            {
                _second.Reset();
                _minute.Increment();

                if (_minute.Tick > 59)
                {
                    _minute.Reset();
                    _hour.Increment();

                    if (_hour.Tick > 23)
                    {
                        Reset();
                    }
                }
            }
        }

        public void Reset()
        {
            _second.Reset();
            _minute.Reset();
            _hour.Reset();
        }

        public string CurrentTime()
        {
            return $"{_hour.Tick:D2}:{_minute.Tick:D2}:{_second.Tick:D2}";
        }
    }
}