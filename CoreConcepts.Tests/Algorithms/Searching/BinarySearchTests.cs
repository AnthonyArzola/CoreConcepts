using System;

using Xunit;

using CoreConcepts.Algorithms.Searching;

namespace CoreConcepts.Tests.Algorithms.Searching
{
    public class BinarySearchTests
    {
        [Fact]
        public void Test_Empty_Array()
        {
            int[] array = new int[] { };

            int index = BinarySearch.Search(array, 33);

            Assert.Equal(index, -1);
        }

        [Fact]
        public void Test_With_Valid_Value()
        {
            int[] array = new int[] { 1, 2, 15, 35, 46, 78, 100 };

            // Compare framework functionality against CoreConcepts.BinarySearch
            int index1 = Array.IndexOf(array, 78);
            int index2 = BinarySearch.Search(array, 78);

            Assert.Equal(index1, index2);
        }

        [Fact]
        public void Test_With_Invalid_Value()
        {
            int[] array = new int[] { 1, 2, 15, 35, 46, 78, 100 };

            // Compare framework search functionality against CoreConcepts.BinarySearch
            int index1 = Array.IndexOf(array, 33);
            int index2 = BinarySearch.Search(array, 33);

            Assert.Equal(index1, index2);

            Assert.Equal(index2, -1);
        }
    }
}
