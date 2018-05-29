namespace CoreConcepts.Algorithms.Sorting
{
    public class InsertionSort
    {
        /// <summary>
        /// Take element within unsorted portion and insert
        /// into proper place within sorted section.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <remarks>Start at second element.</remarks>
        public static void Sort(int[] array)
        {
            if (array.Length == 0)
                return;

            // Start at second element. Single element is considered sorted.
            for (int unsortedIndex = 1; unsortedIndex < array.Length; unsortedIndex++)
            {
                int sortedIndex = unsortedIndex - 1;

                // Copy current unsorted value
                int value = array[unsortedIndex];

                while (sortedIndex >= 0 && array[sortedIndex] > value)
                {
                    // Move sorted values greater than current unsorted value
                    // by shifting them to the right.

                    // Example:
                    // [4 8 9 5 30 20]
                    // -----^         sortedIndex
                    // -------^       unsortedIndex
                    // Interate backwards and insert array[unsortedIndex], value of 5
                    // at the appropriate location (between 4 and 8)

                    // [4 8 9 5 30 20] set value = 5
                    // -----^           sortedIndex

                    // [4 8 9 9 30 20] copy 9 right, sortedIndex--
                    // ---^             sortedIndex

                    // [4 8 8 9 30 20] copy 8 right, sortedIndex--
                    // -^               sortedIndex

                    // Shift sorted value to the right, decrement index
                    array[sortedIndex + 1] = array[sortedIndex];
                    sortedIndex--;
                }

                // [4 8 8 9 30 20] copy unsorted value into [sortedIndex + 1]
                // -^               sortedIndex
                // [4 5 8 9 30 20]

                // Copy value into sorted section
                array[sortedIndex + 1] = value;
            }

        }


    }
}
