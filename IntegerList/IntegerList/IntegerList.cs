using System;

namespace IntegerList
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        public int Count { get; private set; }

        public IntegerList()
        {
            _internalStorage = new int[4];
            Count = 0;
        }

        public IntegerList(int initialSize)
        {
            if (initialSize <= 0)
                throw new ArgumentException("Initial size must be a positive integer!");

            _internalStorage = new int[initialSize];
            Count = 0;
        }

        public void Add(int item)
        {
            if (Count == _internalStorage.Length)
            {
                int[] t = new int[Count << 1];
                _internalStorage.CopyTo(t, 0);

                _internalStorage = t;
            }

            _internalStorage[Count++] = item;
        }

        public bool Remove(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
                if (_internalStorage[i] == item)
                    return RemoveAt(i);

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < Count)
            {
                if (index != (Count - 1))
                    Array.Copy(_internalStorage, index + 1, _internalStorage, index, Count - (index + 1));

                --Count;
                return true;
            }

            throw new IndexOutOfRangeException();
        }

        public int GetElement(int index)
        {
            if (index < Count)
                return _internalStorage[index];

            throw new IndexOutOfRangeException();
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < Count; i++)
                if (_internalStorage[i] == item)
                    return i;

            return -1;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
                if (_internalStorage[i] == item)
                    return true;

            return false;
        }
    }
}