using System;
namespace SemesterTest
{
	public class Batch : Thing
	{
		private string _number;
		private string _name;
		private List<Thing> _items;

		public Batch(string number, string name) : base(number, name)
		{
			_number = number;
			_name = name;
			_items = new List<Thing>();
		}

		public void Add(Thing single)
		{
			_items.Add(single);
		}

		public override void Print()
		{
            Console.WriteLine($"Batch Sale: {Number}, {Name}");
			if (_items.Count == 0)
			{
				Console.WriteLine("Empty Order.");
            }
			else
			{
				int i = 0;
                foreach (Thing t in _items)
                {
                    i++;
                    if (t is Transaction)
					{
                        Console.WriteLine($"#{i}, {t.Name}, ${t.Total()}");
                    }
                    else
                    {
                        Console.WriteLine($"#{i}, Batch: {t.Number}, {t.Name}, ${t.Total()}");
                    }
                }
                Console.WriteLine($"Total: ${Total()}");
            }
		}

		public override decimal Total()
		{
			decimal i = 0;
			foreach(Thing t in _items)
			{
				i += t.Total();
			}
			return i;
		}

		public string Number { get { return _number; } }
        public string Name { get { return _name; } }
    }
}

