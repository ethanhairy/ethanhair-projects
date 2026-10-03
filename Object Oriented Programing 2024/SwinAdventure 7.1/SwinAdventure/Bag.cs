using System;
using System.Xml.Linq;
namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) { return this; }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            return null;
        }

        public string FullDescription
        {
            get { return $"In the {Name} you can see:\n" + Inventory.ItemList; }
        }

        public Inventory Inventory { get { return _inventory; } }
    }
}
