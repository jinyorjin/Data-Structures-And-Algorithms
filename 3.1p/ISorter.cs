using System;
using System.Collections.Generic;

namespace Vector
{
    public interface ISorter
    {
        void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>;
    }
}
//This is the ISorter interface.  
//It defines one generic method called Sort.
//The method sorts the array starting from index, and sorts num elements.  
//It uses a custom comparer, or a default one if none is given.  
//It also throws exceptions for invalid inputs.
