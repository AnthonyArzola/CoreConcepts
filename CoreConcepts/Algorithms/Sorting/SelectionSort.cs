namespace CoreConcepts.Algorithms.Sorting
{
    public class SelectionSort
    {
        /// <summary>
        /// Sorting algorithm that finds smallest value and
        /// inserts into last known sorted index.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        public static void Sort(int[] array)
        {
            if (array.Length == 0)
                return;

            // Linear algorithm. Finds smallest item and moved it to correct location.
            // - Iterate from first unsorted item to end
            // -- Identify smallest item
            // -- Swap smallest item with first unsorted item

            // Ex: [15, 25, 30, 300, 200, 100]
            // ------------------^
            // unsortedIndex = 4
            // smallestValue = [100], smallestValueIndex = 5
            // swap [unsortedIndex] and [smallestValueIndex] <-> swap [300] and [100]

            // Process input array once
            for (int unsortedIndex = 0; unsortedIndex < array.Length; unsortedIndex++)
            {
                int smallestValueIndex = unsortedIndex;
                int index = unsortedIndex;

                // Find smallest value within unsorted section (RHS)
                while (index < array.Length)
                {
                    if (array[index] <= array[smallestValueIndex])
                    {
                        // Found smaller value
                        smallestValueIndex = index;
                    }
                    index++;
                }

                // Swap smallest value with last known unsorted index
                int temp = array[unsortedIndex];
                array[unsortedIndex] = array[smallestValueIndex];
                array[smallestValueIndex] = temp;
            }
        }

    }
}
