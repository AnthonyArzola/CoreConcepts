using Core = CoreConcepts.DataStructures.Linear;

using Xunit;

namespace CoreConcepts.Tests.DataStructures.Linear
{
    public class QueueTests
    {
        [Fact]
        public void Test_Add()
        {
            Core.Queue<int> queue = new Core.Queue<int>();
            Assert.Empty(queue);

            queue.Enqueue(5);
            Assert.NotEmpty(queue);
            Assert.Equal(1, queue.Count);
            Assert.Equal(5, queue.FirstItem);
            Assert.Equal(queue.FirstItem, queue.LastItem);
        }

        [Fact]
        public void Test_Add_Remove()
        {
            Core.Queue<int> queue = new Core.Queue<int>();
            Assert.Empty(queue);

            queue.Enqueue(20);
            queue.Enqueue(40);
            Assert.NotEmpty(queue);
            Assert.Equal(2, queue.Count);
            Assert.Equal(40, queue.LastItem);
            Assert.NotEqual(queue.FirstItem, queue.LastItem);

            var dequeuedItem = queue.Dequeue();
            Assert.Equal(20, dequeuedItem);
            Assert.Equal(1, queue.Count);

            queue.Dequeue();
            Assert.Empty(queue);
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void Test_Clear()
        {
            Core.Queue<int> queue = new Core.Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);
            Assert.Equal(2, queue.Count);

            queue.Clear();
            Assert.Equal(0, queue.Count);
            Assert.Empty(queue);

        }

    }
}
