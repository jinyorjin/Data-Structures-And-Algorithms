using System;
using System.Collections.Generic;
using Vector;


namespace Vector
{

    public class AscendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A - B;
        }
    }

    public class DescendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return B - A;
        }
    }

    public class EvenNumberFirstComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A % 2 - B % 2;
        }
    }

    class Tester
    {
        private static bool CheckAscending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] > vector[i + 1]) return false;
            return true;
        }

        private static bool CheckDescending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] < vector[i + 1]) return false;
            return true;
        }

        private static bool CheckEvenNumberFirst(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] % 2 > vector[i + 1] % 2) return false;
            return true;
        }

        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 20;
            int[] data = new int[problem_size]; data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++) data[i] = 100 + k.Next(900);

            Vector<int> vector = new Vector<int>(problem_size);

            // ------------------ Default Sort ----------------------------------
            try
            {
                Console.WriteLine("\nTest A: Sort integer numbers applying Default Sort with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(null, new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "A";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest B: Sort integer numbers applying Default Sort with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(null, new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "B";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest C: Sort integer numbers applying Default Sort with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(null, new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "C";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            // ------------------ BubbleSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest D: Sort integer numbers applying BubbleSort with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                //I tested the sorting algorithms using multiple comparers: ascending, descending, and even-number-first.  
//                I also made sure to uncomment all test cases in Tester.cs.

                                vector.Sort(new BubbleSort(),new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "D";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest E: Sort integer numbers applying BubbleSort with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new BubbleSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "E";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest F: Sort integer numbers applying BubbleSort with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new BubbleSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "F";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }



            // ------------------ SelectionSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest G: Sort integer numbers applying SelectionSort with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new SelectionSort(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "G";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest H: Sort integer numbers applying SelectionSort with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new SelectionSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "H";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest I: Sort integer numbers applying SelectionSort with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new SelectionSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "I";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }



            // ------------------ InsertionSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest J: Sort integer numbers applying InsertionSort with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new InsertionSort(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "J";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest K: Sort integer numbers applying InsertionSort with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new InsertionSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "K";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest L: Sort integer numbers applying InsertionSort with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new InsertionSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "L";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }    // BubbleSort 
            Console.WriteLine("\nDirect BubbleSort Test:");
            int[] bubbleData = { 4, 3, 1, 5, 2 };
            BubbleSort bubble = new BubbleSort();
            bubble.Sort(bubbleData, 0, bubbleData.Length, new AscendingIntComparer());
            Console.WriteLine("Bubble sorted data: " + string.Join(", ", bubbleData));

            // InsertionSort 
            Console.WriteLine("\nDirect InsertionSort Test:");
            int[] insertionData = { 10, 9, 7, 3, 1 };
            InsertionSort insertion = new InsertionSort();
            insertion.Sort(insertionData, 0, insertionData.Length, new DescendingIntComparer());
            Console.WriteLine("Insertion sorted data: " + string.Join(", ", insertionData));

            // SelectionSort 
            Console.WriteLine("\nDirect SelectionSort Test:");
            int[] selectionData = { 2, 5, 3, 6, 4 };
            SelectionSort selection = new SelectionSort();
            selection.Sort(selectionData, 0, selectionData.Length, new EvenNumberFirstComparer());
            Console.WriteLine("Selection sorted data: " + string.Join(", ", selectionData));

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
          

        
            Console.ReadKey();
        }

    }
}
