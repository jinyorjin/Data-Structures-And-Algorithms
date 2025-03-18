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

        public Vector(int capacity)
        {
            data = new T[capacity];
        }

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
            data[Count] = element;
            Count++;
        }

        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(data[i], element)) return i;
            }
            return -1;
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException("Invalid index");

            if (Count == Capacity)
                ExtendData(DEFAULT_CAPACITY);

            for (int i = Count; i > index; i--)
            {
                data[i] = data[i - 1];
            }

            data[index] = element;
            Count++;
        }

        public void Clear()
        {
            Array.Clear(data, 0, Count);
            Count = 0;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public bool Remove(T element)
        {
            int index = IndexOf(element);
            if (index == -1) return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Invalid index");

            for (int i = index; i < Count - 1; i++)
            {
                data[i] = data[i + 1];
            }

            Count--;
            data[Count] = default; // Nullify the last element
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < Count; i++)
            {
                sb.Append(data[i]?.ToString() ?? "null");
                if (i < Count - 1)
                    sb.Append(", ");
            }
            sb.Append("]");
            return sb.ToString();
        }

        public void Sort()
        {
            if (Count == 0) return;
            if (!(typeof(IComparable<T>).IsAssignableFrom(typeof(T))))
            {
                throw new InvalidOperationException($"Type {typeof(T).Name} does not implement IComparable<T>.");
            }
            Array.Sort(data, 0, Count);
        }

        public void Sort(IComparer<T> comparer)
        {
            if (Count == 0) return;
            Array.Sort(data, 0, Count, comparer ?? Comparer<T>.Default);
        }
    }

    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public int CompareTo(Student other)
        {
            return Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return $"{Id}[{Name}]";
        }
    }

    public class AscendingIDComparer : IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            return a.Id.CompareTo(b.Id);
        }
    }

    public class DescendingNameDescendingIdComparer : IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            int nameComparison = string.Compare(b.Name, a.Name, StringComparison.Ordinal);
            return nameComparison != 0 ? nameComparison : b.Id.CompareTo(a.Id);
        }
    }
}
