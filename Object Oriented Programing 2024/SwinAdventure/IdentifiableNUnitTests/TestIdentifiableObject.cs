using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SwinAdventure;

namespace TestIdentifiableObject
{
    [TestFixture]
    public class TestIdentifiableObject
    {

        private IdentifiableObject _testableObject;
        private string _testableString;
        private string[] _testableArray;

        private IdentifiableObject _testableEmptyObject;
        private string _testableEmptyString;
        private string[] _testableEmptyArray;


        [SetUp]
        public void Setup()
        {
            _testableString = "ethan";
            _testableArray = new string[] { "ethan", "conner" };
            _testableObject = new IdentifiableObject(_testableArray);
            _testableObject.AddIdentifier(_testableString);

            _testableEmptyString = "";
            _testableEmptyArray = new string[] { };
            _testableEmptyObject = new IdentifiableObject(_testableEmptyArray);
            _testableEmptyObject.AddIdentifier(_testableEmptyString);
        }


        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(_testableObject.AreYou(_testableString));
        }


        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(_testableObject.AreYou("Bob"));
        }


        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(_testableObject.AreYou("ETHAN"));
        }


        [Test]
        public void TestFirstID()
        {
            Assert.AreEqual("ethan", _testableObject.FirstId);
            Assert.AreNotEqual("conner", _testableObject.FirstId);
        }


        [Test]
        public void TestFirstIDWithNoID()
        {
            Assert.AreEqual("", _testableEmptyObject.FirstId);
        }


        [Test]
        public void TestAddID()
        {
            _testableObject.AddIdentifier("szymon");
            _testableObject.AddIdentifier("mitch");

            Assert.IsTrue(_testableObject.AreYou("szymon"));
            Assert.IsTrue(_testableObject.AreYou("mitch"));
        }
    }
}
