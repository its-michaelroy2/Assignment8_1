using System;

namespace Assignment8_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 8.1, 8.2, 8.3");
            Console.WriteLine("========================\n");

            // Example array
            int[] arr1 = { 64, 34, 21, 10, 22, 11, 95 };
            int[] arr2 = { 64, 34, 21, 10, 22, 11, 95 };
            int[] arr3 = { 64, 34, 21, 10, 22, 11, 95 };

            Console.WriteLine("Original array:");
            PrintArray(arr1);

            Console.WriteLine("\n8.1 Shell Sort:");
            ShellSort(arr1);
            PrintArray(arr1);

            Console.WriteLine("\n8.2 Merge Sort:");
            MergeSort(arr2, 0, arr2.Length - 1);
            PrintArray(arr2);

            Console.WriteLine("\n8.3 Quick Sort:");
            QuickSort(arr3, 0, arr3.Length - 1);
            PrintArray(arr3);
        }

        static void ShellSort(int[] arr)
        {
            int n = arr.Length;

            // Start with a big gap, then reduce the gap
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort for this gap size.
                // The first gap elements a[0..gap-1] are already in gapped order
                // keep adding one more el until the entire array is gap sorted
                for (int i = gap; i < n; i++)
                {
                    // add a[i] to the elements that have been gap sorted
                    // save a[i] in temp and make a hole at position i
                    int temp = arr[i];

                    // shift earlier gap-sorted elements up until correct location for a[i] is found
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }

                    // put tempin its correct location
                    arr[j] = temp;
                }
            }
        }

        // 8.2 Merge Sort
        static void MergeSort(int[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

                MergeSort(arr, leftIndex, middleIndex);
                MergeSort(arr, middleIndex + 1, rightIndex);

                Merge(arr, leftIndex, middleIndex, rightIndex);
            }
        }

        static void Merge(int[] arr, int leftIndex, int middleIndex, int rightIndex)
        {
            int leftArraySize = middleIndex - leftIndex + 1;
            int rightArraySize = rightIndex - middleIndex;

            int[] leftArray = new int[leftArraySize];
            int[] rightArray = new int[rightArraySize];

            // Copy the left half of the range into leftArray
            Array.Copy(arr, leftIndex, leftArray, 0, leftArraySize);

            // Copy the right half of the range into rightArray
            //+1 is due to middleIndex being included in the left array, so we start from the next element
            Array.Copy(arr, middleIndex + 1, rightArray, 0, rightArraySize);

            int leftArrayIndex = 0, rightArrayIndex = 0;
            int mergedArrayIndex = leftIndex;

            while (leftArrayIndex < leftArraySize && rightArrayIndex < rightArraySize)
            {
                if (leftArray[leftArrayIndex] <= rightArray[rightArrayIndex])
                {
                    arr[mergedArrayIndex] = leftArray[leftArrayIndex];
                    leftArrayIndex++;
                }
                else
                {
                    arr[mergedArrayIndex] = rightArray[rightArrayIndex];
                    rightArrayIndex++;
                }
                mergedArrayIndex++;
            }

            while (leftArrayIndex < leftArraySize)
            {
                arr[mergedArrayIndex] = leftArray[leftArrayIndex];
                leftArrayIndex++;
                mergedArrayIndex++;
            }

            while (rightArrayIndex < rightArraySize)
            {
                arr[mergedArrayIndex] = rightArray[rightArrayIndex];
                rightArrayIndex++;
                mergedArrayIndex++;
            }
        }

        // 8.3 Quick Sort
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }


        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}