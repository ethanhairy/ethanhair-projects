using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwinAdventure;

namespace TestItem
{
    [TestFixture]
    public class TestItem
    {
        private Item _testShovel;

        [SetUp]
        public void Setup()
        {
            _testShovel = new Item(new string[] { "shovel", "spade"}, "a shovel", "this is a shovel");
        }

        [Test]
        public void TestItemIdentifiable()
        {
            Assert.IsFalse(_testShovel.AreYou("sword"));
            Assert.IsTrue(_testShovel.AreYou("shovel"));
            Assert.IsTrue(_testShovel.AreYou("SHOVEL"));
            Assert.IsTrue(_testShovel.AreYou("Spade"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("a shovel (shovel)", _testShovel.ShortDescription);
            Assert.AreNotEqual("a shovel (spade)", _testShovel.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual("this is a shovel", _testShovel.FullDescription);
            Assert.AreNotEqual("a shovel (shovel)", _testShovel.FullDescription);
            Assert.AreNotEqual("this is a spade", _testShovel.FullDescription);
        }
    }
}
