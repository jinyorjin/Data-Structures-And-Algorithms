
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vector
{
    public class Vector<T> where T : IComparable<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity
        {
            get { return data.Length; }
        }

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
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

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            data[Count] = element;
            Count++;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.
        // Inserts an element at the specified index and shifts elements to the right
        public void Insert(int index, T element)
        {
            // Check if the index is within a valid range
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException("Invalid index");

            // If the vector is full, expand its capacity before inserting
            if (Count == Capacity)
                ExtendData(DEFAULT_CAPACITY);

            // Shift elements to the right to make space for the new element
            for (int i = Count; i > index; i--)
            {
                data[i] = data[i - 1];
            }

            // Insert the new element at the given index
            data[index] = element;
            Count++; // Increase the number of stored elements
        }

        // Clears all elements in the vector by resetting Count to 0
        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                data[i] = default(T); // Reset each element to default value 
            }
            Count = 0; // Reset the count
        }


        // Checks if the vector contains the specified element
        public bool Contains(T element)
        {
            return IndexOf(element) != -1; // Uses IndexOf to determine if the element exists
        }

        // Removes the first occurrence of the specified element
        public bool Remove(T element)
        {
            int index = IndexOf(element); // Find the index of the element
            if (index == -1) return false; // If the element is not found, return false

            RemoveAt(index); // Remove the element at the found index
            return true;
        }

        // Removes the element at the specified index and shifts remaining elements to the left
        public void RemoveAt(int index)
        {
            // Ensure the index is within valid bounds
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Invalid index");

            // Shift elements left to fill the removed position
            for (int i = index; i < Count - 1; i++)
            {
                data[i] = data[i + 1];
            }

            Count--; // Decrease the count of elements
        }

        // Converts the vector's content into a string format like "[a, b, c]"
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("["); // Start with an opening bracket

            for (int i = 0; i < Count; i++)
            {
                sb.Append(data[i]); // Add each element to the string
                if (i < Count - 1)
                    sb.Append(", "); // Add commas between elements except for the last one
            }

            sb.Append("]"); // Add the closing bracket
            return sb.ToString(); // Return the formatted string
        }

        // Default Sort (no comparer)
        public void Sort()
        {
            Array.Sort(data, 0, Count);
        }

        // Method to sort elements of the vector using the provided comparer
        // Elements of type T will be sorted according to the order defined by the comparer
        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(data, 0, Count, comparer);// Sorts the internal array 'data' using the given comparer
        }
        //Here is my Vector<T> class.  
        //I added this method to support custom sorting:
           //  This method checks whether a sorting algorithm is given.
         //If not, it uses Array.Sort by default.  
    //Otherwise, it uses the algorithm's Sort method.  
    //I also added where T : IComparable<T> to the class definition to support comparison.

        public void Sort(ISorter algorithm, IComparer<T> comparer)
        {
            if (algorithm == null)
            {
                Array.Sort(data, 0, Count, comparer ?? Comparer<T>.Default);
            }
            else
            {
                algorithm.Sort(data, 0, Count, comparer ?? Comparer<T>.Default);
            }
        }
    }
    }
