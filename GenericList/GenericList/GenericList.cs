using System;

namespace GenericList
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _memory;
        public int Count { get; private set; }

        public GenericList ()
        {
            _memory = new X[4];
            Count = 0;
        }

        public GenericList (int initialSize)
        {
            if(initialSize < 0)
                throw new ArgumentException("Initial size cannot be a negative number!");

            _memory = new X[initialSize];
            Count = 0;
        }

        public void Add(X item)
        {
            if (Count == _memory.Length)
            {
                X[] t = new X[Count << 1];
                _memory.CopyTo(t, 0);

                _memory = t;
            }

            _memory[Count++] = item;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < Count; i++)
                if (_memory[i].Equals(item))
                    return true;

            return false;
        }

        public X GetElement(int index)
        {
            if (index < Count)
                return _memory[index];

            throw new IndexOutOfRangeException();
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < Count; i++)
                if (_memory[i].Equals(item))
                    return i;

            return -1;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < _memory.Length; i++)
                if (_memory[i].Equals(item))
                    return RemoveAt(i);

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < Count)
            {
                if (index != (Count - 1))
                    Array.Copy(_memory, index + 1, _memory, index, Count - (index + 1));

                --Count;
                return true;
            }

            throw new IndexOutOfRangeException();
        }
    }
}