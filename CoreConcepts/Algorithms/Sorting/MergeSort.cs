namespace CoreConcepts.Algorithms.Sorting
{
    public class MergeSort
    {
        public static void Sort(int[] array)
        {
            if (array.Length == 0)
                return;

            Sort(array, 0, array.Length -1);
        }

        private static void Sort(int[] array, int leftIndex, int rightIndex)
        {
            //Console.WriteLine($"\nCalled MergeSort(L={leftIndex}, R={rightIndex})");
            if (leftIndex < rightIndex) // We have at least two elements
            {
                //Console.WriteLine($" {leftIndex}<{rightIndex} condition met");

                // 1. Divide: find midpoint (leftIndex+rightIndex)/2 (will round down)
                int middleIndex = (leftIndex + rightIndex) / 2;
                //Console.WriteLine($" middleIndex={middleIndex}");

                // 2. Conquer: recursively call MergeSort on 2 halves
                //Console.WriteLine($" Recurse LEFT (L={leftIndex}, R={middleIndex})");
                Sort(array, leftIndex, middleIndex);
                //Console.WriteLine($" Recurse RIGHT (L={middleIndex+1}, R={rightIndex})");
                Sort(array, middleIndex + 1, rightIndex);

                // 3. Merge: combine 2 halves in sorted order
                Merge(array, leftIndex, middleIndex, rightIndex);
            }
            else
            {
                //Console.WriteLine($" {leftIndex}<{rightIndex} condition not met, skipped MergeSort(L={leftIndex}, R={rightIndex})");
            }
        }

        private static void Merge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            //Console.WriteLine($" * Called Merge(L={leftIndex}, middleIndex={middleIndex}, R={rightIndex})");

            int i = 0;
            int j = 0;

            // Ex: int[7] = {300, 5, 1, 8, 100, 2, 10}
            // -------------------------^
            // middleIndex = (Left+Right)/2 = (0+6)/2 = 3

            // leftSize  = {3} - 0 + 1 = 4
            // rightSize = 6 - {3} = 3

            // Create 2 temp sub-arrays
            int leftSize = middleIndex - leftIndex + 1; // Index is 0-based, but we are calculating size, add 1 to account for difference
            int[] leftArray = new int[leftSize];

            int rightSize = rightIndex - middleIndex;
            int[] rightArray = new int[rightSize]; // Delta between (right index and midpoint) = second half array size

            // Populate leftArray using source array
            for (i = 0; i < leftSize; i++)
            {
                leftArray[i] = array[leftIndex + i];
            }
            // Populate rightArray using source array
            for (j = 0; j < rightSize; j++)
            {
                rightArray[j] = array[(middleIndex + 1) + j];
            }

            // Reset index vars
            i = 0;
            j = 0;
            int arrayIndex = leftIndex;

            // Copy items from temp sub-arrays into source array in ascending order
            while (i < leftSize && j < rightSize)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[arrayIndex] = leftArray[i];
                    i++;
                }
                else
                {
                    array[arrayIndex] = rightArray[j];
                    j++;
                }

                arrayIndex++;
            }

            // Copy remaining left array elements
            while (i < leftSize)
            {
                array[arrayIndex] = leftArray[i];
                i++;
                arrayIndex++;
            }

            // Copy remaining right array elements
            while (j < rightSize)
            {
                array[arrayIndex] = rightArray[j];
                j++;
                arrayIndex++;
            }
        }

    }
}
