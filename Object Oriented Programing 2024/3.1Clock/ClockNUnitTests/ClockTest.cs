using NUnit.Framework;
using Clock;

namespace Clock
{
    [TestFixture]
    public class ClockTest
    {
        private Clock _clock;

        [SetUp]
        public void Setup()
        {
            _clock = new Clock();
        }


        [Test]
        public void TestInitialise()
        {
            Assert.AreEqual("00:00:00", _clock.CurrentTime());
        }

        [TestCase(0, "00:00:00")] //0secs = 0
        [TestCase(60, "00:01:00")] //60secs = 1min
        [TestCase(120, "00:02:00")] //120secs = 2mins
        [TestCase(3600, "01:00:00")] //3600secs = 1hr
        public void TestIncrement(int tick, string currentTime)
        {
            for (int i = 0; i < tick; i++)
            {
                _clock.Tick();
            }

            Assert.AreEqual(currentTime, _clock.CurrentTime());
        }

        [TestCase("00:01:00", "00:00:59")] 
        [TestCase("01:00:00", "00:59:59")] 
        [TestCase("00:00:00", "23:59:59")] //expect reset after 23 'hours', 59 'minutes' and 59 'seconds' ticks
        public void TestRollover(string expectTime, string set)
        {
            string[] array = set.Split(":");
            _clock._hour = new Counter("hour", int.Parse(array[0]));
            _clock._minute = new Counter("minute", int.Parse(array[1]));
            _clock._second = new Counter("second", int.Parse(array[2]));

            _clock.Tick();

            Assert.AreEqual(expectTime, _clock.CurrentTime());
        }

        [Test]
        public void TestReset()
        {
            for (int i = 0; i < 86400; i++) //86400 secs = 24 hours
            {
                _clock.Tick();
            }
            _clock.Reset(); //reset as 24hrs = 00:00:00 in 24hr time

            Assert.AreEqual("00:00:00", _clock.CurrentTime());
        }
    }
}