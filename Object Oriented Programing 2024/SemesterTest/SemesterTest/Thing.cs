using System;
namespace SemesterTest
{
	public abstract class Thing
	{
		private string _number;
		private string _name;

		public Thing(string number, string name)
		{
			_number = number;
			_name = name;
		}

		public abstract void Print();

		public abstract decimal Total();

        public string Number { get { return _number; } }
        public string Name { get { return _name; } }
    }
}

