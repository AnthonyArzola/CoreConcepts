using System.Linq;

using CoreConcepts.DataStructures.Linear;

using Xunit;

namespace CoreConcepts.Tests.DataStructures.Linear
{
    public class LinkedListTests
    {
        [Fact]
        public void Test_Add_First()
        {
            // Create new linked list and init with value of 5
            LinkedList<int> list = new LinkedList<int>(5);
            Assert.Single(list);

            // Ensure that First = 5
            Assert.NotNull(list.First);
            Assert.Equal(5, list.First.Value);
            // Ensure that Last = 5
            Assert.NotNull(list.Last);
            Assert.Equal(5, list.Last.Value);

            // Add new 'first'and check First, Next, Last properties
            list.AddFirst(10); // 10 -> 5 -> null
            Assert.Equal(2, list.Count());
            Assert.Equal(10, list.First.Value);
            Assert.Equal(5, list.First.Next.Value);
            Assert.Equal(5, list.Last.Value);
        }

        [Fact]
        public void Test_Add_Last()
        {
            // Create empty linked list
            LinkedList<int> list = new LinkedList<int>();
            Assert.Empty(list);

            // Ensure First and Last are null
            Assert.Null(list.First);
            Assert.Null(list.Last);

            // Add last and check size, first and list properties
            list.AddLast(15);
            Assert.Single(list);
            Assert.NotNull(list.First);
            Assert.NotNull(list.Last);
            Assert.Equal(15, list.First.Value);
            Assert.Equal(15, list.Last.Value);
        }

        [Fact]
        public void Test_Remove_First()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.RemoveFirst();
            list.RemoveLast();

            list.AddFirst(2); // 2 -> null
            list.AddFirst(1); // 1 -> 2 -> null

            list.RemoveFirst();
            Assert.Equal(2, list.First.Value);
        }

        [Fact]
        public void Test_Remove_Last()
        {
            LinkedList<int> list = new LinkedList<int>(20);
            Assert.Single(list); // 20 -> null
            Assert.Contains(20, list);
            Assert.Equal(20, list.Last.Value);
            Assert.Equal(20, list.First.Value);

            list.AddFirst(30); // 30 -> 20 -> null
            Assert.Contains(30, list);
            Assert.Equal(30, list.First.Value);
            Assert.Equal(20, list.Last.Value);

            list.AddFirst(40); // 40 -> 30 -> 20 -> null
            Assert.Contains(40, list);
            Assert.Equal(40, list.First.Value);
            Assert.Equal(20, list.Last.Value);

            list.AddFirst(50); // 50 -> 40 -> 30 -> 20 -> null
            Assert.Contains(50, list);
            Assert.Equal(50, list.First.Value);
            Assert.Equal(20, list.Last.Value);
            Assert.Equal(4, list.Count());

            list.RemoveLast(); // 50 -> 40 -> 30 -> null
            Assert.DoesNotContain(20, list);
            Assert.Equal(50, list.First.Value);
            Assert.Equal(30, list.Last.Value);
            Assert.Equal(3, list.Count());

            list.RemoveLast(); // 50 -> 40 -> null
            Assert.DoesNotContain(30, list);
            Assert.Equal(50, list.First.Value);
            Assert.Equal(40, list.Last.Value);
            Assert.Equal(2, list.Count());
        }

    }
}
