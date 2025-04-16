using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vector
{
    public class SelectionSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            if (array == null) throw new ArgumentNullException();
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException();
            if (index + num > array.Length) throw new ArgumentException();
            //First, I check if the input array is null, if the index or count is negative,  
  //          or if the index and num go beyond the array bounds.  
//These checks help prevent runtime errors and are required by the task instructions.

            comparer ??= Comparer<K>.Default;
            //If no custom comparer is provided, I use the default comparer for type K.
//            This allows sorting even without passing a specific comparer.


            for (int i = index; i < index + num - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < index + num; j++)
                {
                    if (comparer.Compare(array[j], array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                // Swap
                if (minIndex != i)
                {
                    K temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
             
            }
        }
    }
}