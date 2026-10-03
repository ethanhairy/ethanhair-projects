using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwinAdventure;

namespace TestLookCommand
{
    [TestFixture]
    public class TestLookCommand
    {
        private Command _testLook;
        private Player _player;
        private Bag _testBag;
        private Item _testGem;

        [SetUp]
        public void Setup()
        {
            _testLook = new LookCommand();
            _player = new Player("Ethan", "Student Programmer");
            _testBag = new Bag(new string[] { "bag" }, "a Bag", "this is a bag");
            _testGem = new Item(new string[] { "gem" }, "a Gem", "A bright red Gem");
        }

        [Test]
        public void TestLookAtMe()
        {
            Assert.AreEqual(_player.FullDescription, _testLook.Execute(_player, new string[] { "look", "at", "inventory" }));
        }

        [Test]
        public void TestLookAtGem()
        {
            _player.Inventory.Put(_testGem);

            Assert.AreEqual(_testGem.FullDescription, _testLook.Execute(_player, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void TestLookAtUnk()
        {
            Assert.AreEqual("I can't find the gem", _testLook.Execute(_player, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            _player.Inventory.Put(_testGem);

            Assert.AreEqual(_testGem.FullDescription, _testLook.Execute(_player, new string[] { "look", "at", "gem", "in", "inventory" }));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            _player.Inventory.Put(_testBag);
            _testBag.Inventory.Put(_testGem);

            Assert.AreEqual(_testGem.FullDescription, _testLook.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            _player.Inventory.Put(_testGem);

            Assert.AreEqual("I cannot find the bag", _testLook.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            _player.Inventory.Put(_testBag);

            Assert.AreEqual("I can't find the gem", _testLook.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestInvalidLook()
        {
            _player.Inventory.Put(_testBag);
            _testBag.Inventory.Put(_testGem);

            Assert.AreEqual("I don't know how to look like that", _testLook.Execute(_player, new string[] { "look", "gem" })); //test less than 3 words
            Assert.AreEqual("I don't know how to look like that", _testLook.Execute(_player, new string[] { "look", "at", "gem", "in" })); //test 4 words
            Assert.AreEqual("I don't know how to look like that", _testLook.Execute(_player, new string[] { "look", "at", "gem", "in", "players", "bag" })); //test more than 5 words
            Assert.AreEqual("Error in look input", _testLook.Execute(_player, new string[] { "see", "at", "gem" })); //test 'look' not used
            Assert.AreEqual("What do you want to look at?", _testLook.Execute(_player, new string[] { "look", "around", "gem" })); //test 'at' not used
            Assert.AreEqual("What do you want to look in?", _testLook.Execute(_player, new string[] { "look", "at", "gem", "around", "bag" })); //test 'in' not used
        }
    }
}
