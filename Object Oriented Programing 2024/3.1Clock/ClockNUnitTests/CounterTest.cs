using NUnit.Framework;
using Clock;

namespace Clock
{
    [TestFixture]
    public class TestCounter
    {
        private Counter _testableCounter;

        [SetUp]
        public void Setup()
        {
            _testableCounter = new Counter("Test");
        }


        [Test]
        public void TestStart()
        {
            Assert.AreEqual(0, _testableCounter.Tick);
        }

        [Test]
        public void TestName()
        {
            Assert.AreEqual("Test", _testableCounter.Name);
        }

        [Test]
        public void TestCounterReset()
        {
            _testableCounter.Increment();
            _testableCounter.Reset();

            Assert.AreEqual(0, _testableCounter.Tick);
        }

        [TestCase(10, 10)] //ticks 10 times, expecting 10
        [TestCase(100, 100)] //ticks 100 times, expecting 100
        public void TestCounterIncrement(int tick, int result)
        {
            for (int i = 0; i < tick; i++)
            {
                _testableCounter.Increment();
            }

            Assert.AreEqual(result, _testableCounter.Tick);
        }
    }
}