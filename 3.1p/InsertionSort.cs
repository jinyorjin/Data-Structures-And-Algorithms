﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Vector
{
    //The Insertion Sort shifts values to the right and inserts the key at the correct position.  
//    Selection Sort looks for the smallest element and swaps it with the front.

    public class InsertionSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            if (array == null) throw new ArgumentNullException();
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException();
            if (index + num > array.Length) throw new ArgumentException();

            comparer ??= Comparer<K>.Default;

            for (int i = index + 1; i < index + num; i++)
            {
                K key = array[i];
                int j = i - 1;

                while (j >= index && comparer.Compare(array[j], key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            
            }
        }
    }
}
//I made sure both classes follow the same exception handling and use Comparer<K>.Default when comparer is null.
