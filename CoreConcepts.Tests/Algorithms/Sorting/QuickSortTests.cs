using System;
using System.Linq;

using CoreConcepts.Algorithms.Sorting;

using Xunit;

namespace CoreConcepts.Tests.Algorithms.Sorting
{
    public class QuickSortTests
    {
        [Fact]
        public void Test_Sorting_Empty_Array()
        {
            int[] array = new int[] { };

            try
            {
                QuickSort.Sort(array);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.True(false, $"Unable to perform sort on empty array. Exception is: {ex.Message}");
            }

            Assert.Empty(array);
        }

        [Fact]
        public void Test_Sorting()
        {
            // Sort using CoreConcepts implementation
            int[] unsortedArray = new int[] { 300, 5, 1, 8, 100, 2, 10 };
            QuickSort.Sort(unsortedArray);

            // Sort using framework implementation
            int[] unsortedArray2 = new int[] { 300, 5, 1, 8, 100, 2, 10 };
            Array.Sort(unsortedArray2);

            // Compare results
            Assert.True(unsortedArray.SequenceEqual(unsortedArray2), "Sorted arrays do not match.");
        }

        [Fact]
        public void Test_Sorting2()
        {
            // Sort using CoreConcepts implementation
            int[] unsortedArray = new int[] { 38, 27, 43, 3, 9, 82, 10 };
            QuickSort.Sort(unsortedArray);

            // Sort using framework implementation
            int[] unsortedArray2 = new int[] { 38, 27, 43, 3, 9, 82, 10 };
            Array.Sort(unsortedArray2);

            // Compare results
            Assert.True(unsortedArray.SequenceEqual(unsortedArray2), "Sorted arrays do not match.");
        }
    }
}
