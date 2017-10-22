using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericListEnumerator
{
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        readonly GenericList<X> list;
        private int current;

        public GenericListEnumerator(GenericList<X> loadedList)
        {
            current = 0;
            list = loadedList;
        }

        public X Current => list.GetElement(current);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            //int i X[] nisu disposable, pokupit ce ih GC kad GenericList izadje iz scopea.
        }

        public bool MoveNext()
        {
            return (list.Count) > ++current;
        }

        public void Reset()
        {
            current = 0;
        }
    }
}
