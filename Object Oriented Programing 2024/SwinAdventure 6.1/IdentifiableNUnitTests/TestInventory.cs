using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwinAdventure;

namespace TestInventory
{
    [TestFixture]
    public class TestInventory
    {
        private Inventory _testInventory;
        private Item _testShovel;
        private Item _testSword;

        [SetUp]
        public void Setup()
        {
            _testInventory = new Inventory();
            _testShovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "this is a shovel");
            _testSword = new Item(new string[] { "sword" }, "a sword", "this is a sword");
        }

        [Test]
        public void TestFindItem()
        {
            _testInventory.Put(_testShovel);
            _testInventory.Put(_testSword);

            Assert.IsTrue(_testInventory.HasItem(_testShovel.FirstId));
            Assert.IsTrue(_testInventory.HasItem(_testSword.FirstId));
        }

        [Test]
        public void TestNoItemFind()
        {
            _testInventory.Put(_testShovel);

            Assert.IsTrue(_testInventory.HasItem(_testShovel.FirstId));
            Assert.IsFalse(_testInventory.HasItem(_testSword.FirstId));
        }

        [Test]
        public void TestFetchItem()
        {
            _testInventory.Put(_testShovel);
            _testInventory.Put(_testSword);
            Item fetchItem = _testInventory.Fetch(_testShovel.FirstId);

            Assert.AreEqual(_testShovel, fetchItem);
            Assert.AreNotEqual(_testSword, fetchItem);
            Assert.IsTrue(_testInventory.HasItem(_testShovel.FirstId));
        }

        [Test]
        public void TestTakeItem()
        {
            _testInventory.Put(_testShovel);
            Assert.IsTrue(_testInventory.HasItem(_testShovel.FirstId));

            _testInventory.Take(_testShovel.FirstId);
            Assert.IsFalse(_testInventory.HasItem(_testShovel.FirstId));
        }

        [Test]
        public void TestItemList()
        {
            _testInventory.Put(_testShovel);
            _testInventory.Put(_testSword);

            Assert.IsTrue(_testInventory.HasItem(_testShovel.FirstId));
            Assert.IsTrue(_testInventory.HasItem(_testSword.FirstId));

            string expect = "\ta shovel (shovel)\n\ta sword (sword)\n";
            Assert.AreEqual(expect, _testInventory.ItemList);
        }
    }
}