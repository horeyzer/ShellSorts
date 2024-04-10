using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSorts
{
    class Program 
    {
        public static void ShellInsertionSort(int[] arr, out int comparisons, out int swaps) 
        {
            comparisons = 0; 
            swaps = 0; 

            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            { 
                for (int i = gap; i < n; i++)
                { 
                    int key = arr[i];
                    int j = i; 

                    comparisons++;

                    while (j >= gap && arr[j - gap] > key) 
                    {
                        swaps++;
                        arr[j] = arr[j - gap];
                        j -= gap;

                        comparisons++;
                    }
                    arr[j] = key;
                }
            }
        } // end ShellInsertionSort

        public static void ShellBubbleSort(int[] arr, out int comparisons, out int swaps)
        {
            comparisons = 0;
            swaps = 0;

            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = 0; i < n - gap; i++)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        comparisons++;

                        swaps++;
                        int temp = arr[i];
                        arr[i] = arr[i + gap];
                        arr[i + gap] = temp;
                    }
                }
            }
        } // end ShellBubbleSort

        static void Main(string[] args)
        {
            TestSortingAlgorithm("Shell Insertion Sort");
            TestSortingAlgorithm("Shell Bubble Sort");
        } // end Main

        static void TestSortingAlgorithm(string algorithm)
        {
            Console.WriteLine("Testing " + algorithm);

            int[] randomArray = RandomArray(50);
            int[] sortedArray = SortedArray(50);
            int[] reverseSortedArray = ReverseSortedArray(50);

            TestArray(algorithm, "Random", randomArray);

            TestArray(algorithm, "Sorted", sortedArray);

            TestArray(algorithm, "Reverse Sorted", reverseSortedArray);

            Console.WriteLine();
        } // end TestSortingAlgorithm

        static void TestArray(string algorithm, string type, int[] arr)
        {
            int[] copy = new int[arr.Length];
            Array.Copy(arr, copy, arr.Length);

            int comparisons = 0, swaps = 0;

            if (algorithm == "Shell + Insertion Sort")
            {
                ShellInsertionSort(copy, out comparisons, out swaps);
            }
            else if (algorithm == "Shell + Bubble Sort")
            {
                ShellBubbleSort(copy, out comparisons, out swaps);
            }

            Console.WriteLine("Test Case: " + type);
            Console.WriteLine("Comparisons: " + comparisons);
            Console.WriteLine("Swaps: " + swaps);
        } // end TestArray

        static int[] RandomArray(int size)
        {
            Random random = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(100);
            }
            return arr;
        } // end RandomArray

        static int[] SortedArray(int size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = i;
            }
            return arr;
        } // end SortedArray

        static int[] ReverseSortedArray(int size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = size - i;
            }
            return arr;
        } // end ReverseSortedArray
    }
}