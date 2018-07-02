using System;

namespace CoreConcepts.Algorithms.Sorting
{
    public class QuickSort
    {
        public static void Sort(int[] array)
        {
            if (array.Length == 0)
                return;

            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int partitionIndex = Partition(array, lowIndex, highIndex);
                Sort(array, lowIndex, partitionIndex - 1); // Before partition index
                Sort(array, partitionIndex + 1, highIndex); // After partition index
            }
        }

        private static int Partition(int[] array, int lowIndex, int highIndex)
        {
            // Select last element as pivot value
            int pivotValue = array[highIndex];
            
            // Lowest element index
            int lowestIndex = lowIndex;
            int temp;

            // Iterate from low to high, but exclude pivot by subtracting 1.
            for (int index = lowIndex; index <= highIndex - 1; index++)
            {
                // If element is less than pivot, move element to the left
                if (array[index] <= pivotValue)
                {
                    // Swap current element with lowest element
                    temp = array[lowestIndex];
                    array[lowestIndex] = array[index];
                    array[index] = temp;

                    // Increment lowestIndex
                    lowestIndex++;
                }
            }

            // Move pivot into new position (where lowest index left off)
            temp = array[lowestIndex];
            array[lowestIndex] = array[highIndex];
            array[highIndex] = temp;

            // Return calculated partition (pivot) index
            return lowestIndex;
        }

    }
}
