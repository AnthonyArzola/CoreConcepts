using System;
using System.Linq;

using CoreConcepts.Algorithms.Sorting;

using Xunit;

namespace CoreConcepts.Tests.Algorithms.Sorting
{
    public class MergeSortTests
    {
        [Fact]
        public void Test_Empty_Array()
        {
            int[] emptyArray = new int[] { };

            try
            {
                MergeSort.Sort(emptyArray);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Unable to perform sort on empty array. Exception is: {ex.Message}");
            }

            Assert.Empty(emptyArray);
        }

        [Fact]
        public void Test_Unsorted_Array()
        {
            // Sort using CoreConcepts implementation
            int[] unsortedArray = new int[] {38, 27, 43, 3, 9, 82, 10};
            MergeSort.Sort(unsortedArray);

            // Sort using framework implementation
            int[] unsortedArray2 = new int[] {38, 27, 43, 3, 9, 82, 10};
            Array.Sort(unsortedArray2);

            // Compare results
            Assert.True(unsortedArray.SequenceEqual(unsortedArray2), "Sorted arrays do not match.");
        }

        [Fact]
        public void Test_Unsorted_Array2()
        {
            // Sort using CoreConcepts implementation
            int[] unsortedArray = new int[] { 300, 5, 1, 8, 100, 2, 10 };
            MergeSort.Sort(unsortedArray);

            // Sort using framework implementation
            int[] unsortedArray2 = new int[] { 300, 5, 1, 8, 100, 2, 10 };
            Array.Sort(unsortedArray2);

            // Compare results
            Assert.True(unsortedArray.SequenceEqual(unsortedArray2), "Sorted arrays do not match.");
        }

    }
}
