using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class CustomList<Type> : IEnumerable, IEnumerator
    {
        private int _count;
        private int _capacity;
        public int Count
        {
            get
            {
                return _count;
            }
        }
        public int Capacity
        {
            get
            {
                return _capacity;
            }
        }
        private Type[] _array;

        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        public CustomList()
        {
            _count = 0;
            _capacity = 5;
            _array = new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }
        public void Add(Type value)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = value;
            _count++;
        }

        public void GrowSize()
        {
            _capacity *= 2 + 5;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

        public void AddRange(CustomList<Type> elements)
        {
            _capacity = _count + elements.Count;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            int k = 0;
            for (int i = _count; i < _count + elements.Count; i++)
            {
                temp[i] = elements[k];
                k++;
            }
            _array = temp;
            _count = _count + elements.Count;
        }
        public int IndexOf(Type value)
        {
            int index = -1;
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Equals(value))
                {

                    return index;
                }
            }
            return index;
        }

        public void RemoveAt(int index)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                if (i >= index)
                {
                    _array[i] = _array[i + 1];
                }
            }
            _count--;
        }

        public bool RemoveMethod(Type element)
        {
            int position = IndexOf(element);
            if (position >= 0)
            {
                RemoveAt(position);
                return true;
            }
            return false;
        }

        int position;
        public IEnumerator GetEnumerator()
        {
            position = -1;
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if (position < _count - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            position = -1;
        }

        internal void AddRange(List<BookingDetail> tempBookingList)
        {
            throw new NotImplementedException();
        }

        public object Current
        {
            get
            {
                return _array[position];
            }
        }

    }
}