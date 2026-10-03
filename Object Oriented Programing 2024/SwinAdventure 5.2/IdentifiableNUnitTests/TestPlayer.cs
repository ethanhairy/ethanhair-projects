using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwinAdventure;

namespace TestPlayer
{
    [TestFixture]
    public class TestPlayer
    {
        private Player _player;
        private Item _testShovel;
        private Item _testSword;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Ethan", "The Programmer");
            _testShovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "this is a shovel");
            _testSword = new Item(new string[] { "sword" }, "a sword", "this is a sword");
        }

        [Test]
        public void TestPlayerIdentifiable()
        {
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            _player.Inventory.Put(_testShovel);

            Assert.AreEqual(_player.Locate("shovel"), _testShovel);
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.AreEqual(_player.Locate("me"), _player);
            Assert.AreEqual(_player.Locate("inventory"), _player);
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            _player.Inventory.Put(_testSword);

            Assert.AreEqual(_player.Locate("shovel"), null);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            _player.Inventory.Put(_testShovel);
            _player.Inventory.Put(_testSword);
            string expect = $"You are Ethan, The Programmer\n" + "You are carrying:\n" + "\ta shovel (shovel)\n\ta sword (sword)\n";

            Assert.IsTrue(_player.Inventory.HasItem(_testShovel.FirstId));
            Assert.IsTrue(_player.Inventory.HasItem(_testSword.FirstId));
            Assert.AreEqual(expect, _player.FullDescription);
        }
    }
}