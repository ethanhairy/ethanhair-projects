using System;
namespace Clock
{
    public class Counter
    {
        private int _count;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Counter(string Name)
        {
            _name = Name;
            _count = 0;
        }

        public Counter(string Name, int Count)
        {
          _name = Name;
          _count = Count;
        }


        public int Increment()
        {
            _count += 1;
            return _count;
        }

        public int Reset()
        {
            _count = 0;
            return _count;
        }

        public int Tick { get { return _count; } }
    }
}
            

           
