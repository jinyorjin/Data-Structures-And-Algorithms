using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T>
    {
        private const int DEFAULT_CAPACITY = 10;
        private T[] data;
        public int Count { get; private set; } = 0;

        public int Capacity => data.Length;

        public Vector(int capacity) => data = new T[capacity];
        public Vector() : this(DEFAULT_CAPACITY) { }

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        public void Add(T element)
        {
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            data[Count++] = element;
        }

        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);

            for (int i = Count; i > index; i--)
            {
                data[i] = data[i - 1];
            }

            data[index] = element;
            Count++;
        }

        public void Clear() => Count = 0;

        public bool Contains(T element) => IndexOf(element) != -1;

        public bool Remove(T element)
        {
            int index = IndexOf(element);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            for (int i = index; i < Count - 1; i++) data[i] = data[i + 1];
            Count--;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < Count; i++)  // Ensure only valid elements are printed
            {
                sb.Append(data[i]);
                if (i < Count - 1)
                    sb.Append(", ");
            }

            sb.Append("]");
            return sb.ToString();
        }


        // 🛠️ **New Sorting Methods** 🛠️
        public void Sort()
        {
            if (Count > 1)
            {
                T[] tempArray = new T[Count];
                Array.Copy(data, tempArray, Count); // Copy valid elements
                Array.Sort(tempArray, Comparer<T>.Default); // Sort copied elements
                Array.Copy(tempArray, 0, data, 0, Count); // Copy back sorted elements
            }
        }

        public void Sort(IComparer<T> comparer)
        {
            if (Count > 1)
            {
                T[] tempArray = new T[Count];
                Array.Copy(data, tempArray, Count);
                Array.Sort(tempArray, comparer ?? Comparer<T>.Default);
                Array.Copy(tempArray, 0, data, 0, Count);
            }
        }



    }
}
