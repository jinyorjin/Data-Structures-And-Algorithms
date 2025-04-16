using System;
using System.Collections.Generic;
using System.Security.Cryptography;
//Here is my BubbleSort class.  
//It implements the ISorter interface and uses the standard Bubble Sort logic.

namespace Vector
{
    public class BubbleSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            if (array == null) throw new ArgumentNullException();
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException();
            if (index + num > array.Length) throw new ArgumentException();

            comparer ??= Comparer<K>.Default;

            for (int i = 0; i < num - 1; i++)
            {
                for (int j = index; j < index + num - i - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]); // Swap
                    }
                   
                }
            }
        }
    }
}
//I used nested loops to compare and swap elements.  
//This algorithm has O(n^2) time complexity in worst case.  
//It works well for small arrays and helps understand sorting logic.
