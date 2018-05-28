namespace CoreConcepts.Algorithms.Searching
{
    public class BinarySearch
    {
        /// <summary>
        /// Perform binary search on input array.
        /// </summary>
        /// <param name="array">Sorted array of integers.</param>
        /// <param name="value">Value to search for.</param>
        /// <returns>If value is found, associated index is returned.
        /// If value is not found, -1 is returned.
        /// </returns>
        public static int Search(int[] array, int value)
        {
            // Guard against empty source array
            if (array.Length == 0)
                return -1;

            return Search(array, 0, array.Length - 1, value);
        }

        /// <summary>
        /// Recursively call Search until we find value or exhaust all attempts.
        /// </summary>
        /// <param name="array">Source array to search.</param>
        /// <param name="leftIndex">Starting index.</param>
        /// <param name="rightIndex">Ending index.</param>
        /// <param name="value">Value to search for.</param>
        /// <returns>If value is found, associated index is returned.
        /// If value is not found, -1 is returned.
        /// </returns>
        private static int Search(int[] array, int leftIndex, int rightIndex, int value)
        {
            if (leftIndex <= rightIndex)
            {
                // Determin mid-point and check if array value is equal to seach value
                int middleIndex = (leftIndex + rightIndex) / 2;
                
                if (array[middleIndex] == value)
                    return middleIndex;

                if (value > array[middleIndex])
                {
                    // Value is greater than mid-point, search right
                    return Search(array, middleIndex + 1, rightIndex, value);
                }
                else
                {
                    // search left instead
                    return Search(array, leftIndex, middleIndex - 1, value);
                }
            }

            return -1;
        }
    }
}
