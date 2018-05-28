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
            int[] array = new int[]{ };

            try
            {
                BubbleSort.Sort(array);
            }
            catch (Exception ex)
            {
                Assert.True(false, "Calling sort on empty array raised an exception.");
            }

            Assert.Empty(array);
        }

        [Fact]
        public void Test_Sorting()
        {
            int[] array = new[] { 300, 5, 1, 8, 100, 2, 10 };
            int[] array2 = new[] { 300, 5, 1, 8, 100, 2, 10 };

            // Sort using CoreConcepts and framework
            BubbleSort.Sort(array);
            Array.Sort(array2);

            // Compare the results
            Assert.True(array.SequenceEqual(array2));
        }
    }
}
