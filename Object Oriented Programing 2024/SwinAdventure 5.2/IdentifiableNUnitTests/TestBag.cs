using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwinAdventure;

namespace TestBag
{
    [TestFixture]
    public class TestBag
    {
        private Bag _testBag;
        private Bag _testBackpack;
        private Item _testShovel;
        private Item _testSword;

        [SetUp]
        public void Setup()
        {
            _testBag = new Bag(new string[] { "bag", "pouch" }, "Bag", "this is a bag");
            _testBackpack = new Bag(new string[] { "backpack", "pack" }, "Pack", "this is a pack");
            _testShovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "this is a shovel");
            _testSword = new Item(new string[] { "sword" }, "a sword", "this is a sword");
        }

        [Test]
        public void TestBagLocatesItems()
        {
            _testBag.Inventory.Put(_testShovel);

            Assert.AreEqual(_testBag.Locate("shovel"), _testShovel);
            Assert.IsTrue(_testBag.Inventory.HasItem(_testShovel.FirstId));
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Assert.AreEqual(_testBag.Locate("bag"), _testBag);
            Assert.AreEqual(_testBag.Locate("pouch"), _testBag);
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.AreEqual(_testBag.Locate("sword"), null);
        }

        [Test]
        public void TestBagFullDescription()
        {
            _testBag.Inventory.Put(_testSword);
            _testBag.Inventory.Put(_testShovel);
            string expect = $"In the Bag you can see:\n" + "\ta sword (sword)\n\ta shovel (shovel)\n";

            Assert.IsTrue(_testBag.Inventory.HasItem(_testSword.FirstId));
            Assert.IsTrue(_testBag.Inventory.HasItem(_testShovel.FirstId));
            Assert.AreEqual(expect, _testBag.FullDescription);
        }

        [Test]
        public void TestBagInBag()
        {
            _testBag.Inventory.Put(_testShovel);
            _testBag.Inventory.Put(_testBackpack);
            _testBackpack.Inventory.Put(_testSword);

            Assert.AreEqual(_testBag.Locate("shovel"), _testShovel);
            Assert.AreEqual(_testBag.Locate("pack"), _testBackpack);
            Assert.AreNotEqual(_testBag.Locate("sword"), _testSword);
        }
    }
}