namespace CoreConcepts.Algorithms.Sorting
{
    public class BubbleSort
    {
        public static void Sort(int[] array)
        {
            // Guard against empty array
            if (array.Length == 0)
                return;

            bool continueChecking = true;
            while(continueChecking)
            {
                int swapCount = 0;

                for (int index = 0; index < array.Length - 1; index++)
                {
                    // Compare current value against right neighbor
                    // Move/Bubble larger value to the right
                    if (array[index] > array[index + 1])
                    {
                        int temp = array[index + 1];
                        array[index + 1] = array[index];
                        array[index] = temp;

                        swapCount += 1;
                    }
                }

                continueChecking = (swapCount > 0);
            }
        }

    }
}
