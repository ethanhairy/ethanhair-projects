using System;
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
            return Fetch(id) != null;
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