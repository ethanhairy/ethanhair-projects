namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }
}



namespace SwinAdventure
{
	public class IdentifiableObject
	{
		private List<string> _identifiers;

		public IdentifiableObject(string[] idents)
		{
			_identifiers = new List<string>();

            for (int i = 0; i < idents.Length; i++)
            {
                _identifiers.Add(idents[i].ToLower());
            }
        }

		public bool AreYou(string id)
		{
            return _identifiers.Contains(id.ToLower());
        }

		public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _identifiers.First();
                }
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }   
}



namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name { get { return _name; } }
        public string ShortDescription { get { return $"{_name} ({FirstId})"; } }
        public virtual string FullDescription { get { return _description; } } 
    }
}



namespace SwinAdventure
{
    public class Item : GameObject
    {
        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {
        }
    }
}



namespace SwinAdventure
{
	public class Inventory
	{
		private List<Item> _items;

		public Inventory()
		{
			_items = new List<Item>();
		}

		public bool HasItem(string id)
		{
			foreach(Item i in _items)
			{
				if  (i.AreYou(id)) { return true; }
			}
			return false;
		}

		public void Put(Item id)
		{
			_items.Add(id);
		}

		public Item Take(string id)
		{
			Item i = Fetch(id);
			_items.Remove(i);
			return i;
		}

        public Item Fetch(string id)
        {
			foreach (Item i in _items)
			{
				if (i.AreYou(id)) { return i; }
			}
			return null;
        }

		public string ItemList
		{
            get
            {
                string itemList = "";
				foreach (Item i in _items)
				{
					itemList = itemList + $"\t{i.ShortDescription}\n";
				}
                return itemList;
            }
        }
    }
}



namespace SwinAdventure
{
	public class Player : GameObject
	{
		private Inventory _inventory;

		public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
			_inventory = new Inventory();
		}

		public GameObject Locate(string id)
		{
			if (AreYou(id)) { return this; }
			return _inventory.Fetch(id);
        }

        public override string FullDescription
		{
            get { return $"You are {Name}, {base.FullDescription}\n" + "You are carrying:\n" + _inventory.ItemList; }
        }

		public Inventory Inventory { get { return _inventory; } }
	}
}



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