using System;
namespace SemesterTest
{
	public class Sales
	{
		private List<Thing> _orders;

		public Sales()
		{
			_orders = new List<Thing>();
		}

		public void Add(Thing thing)
		{
			_orders.Add(thing);
		}

		public void PrintOrders()
		{
			Console.WriteLine("Sales:");
			decimal i = 0;
			foreach (Thing t in _orders)
			{
				i += t.Total();
				t.Print();
			}
			Console.WriteLine($"Sales total: ${i}");
        }
    }
}

