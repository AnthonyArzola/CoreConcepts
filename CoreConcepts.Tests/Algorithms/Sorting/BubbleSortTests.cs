using System;
using System.Linq;

using CoreConcepts.Algorithms.Sorting;

using Xunit;

namespace CoreConcepts.Tests.Algorithms.Sorting
{
    public class BubbleSortTests
    {
        [Fact]
        public void Test_Empty_Array()
        {
            int[] emptyArray = new int[]{ };

            try
            {
                BubbleSort.Sort(emptyArray);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Unable to perform sort on empty array. Exception is: {ex.Message}");
            }

            Assert.Empty(emptyArray);
        }

        [Fact]
        public void Test_Sorting()
        {
            // Sort using CoreConcepts
            int[] array = new[] { 300, 5, 1, 8, 100, 2, 10 };
            BubbleSort.Sort(array);

            // Sort using framework implementation
            int[] array2 = new[] { 300, 5, 1, 8, 100, 2, 10 };
            Array.Sort(array2);

            // Compare results
            Assert.True(array.SequenceEqual(array2), "Sorted arrays do not match.");
        }
    }
}
