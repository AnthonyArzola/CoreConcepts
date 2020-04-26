using Core = CoreConcepts.DataStructures.Linear;

using Xunit;

namespace CoreConcepts.Tests.DataStructures.Linear
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void Test_Default_Constructor()
        {
            Core.DoublyLinkedList<int> doublyLinkList = new Core.DoublyLinkedList<int>();
            Assert.Empty(doublyLinkList);
            Assert.Equal(0, doublyLinkList.Count);
            Assert.Null(doublyLinkList.FirstNode);
            Assert.Null(doublyLinkList.LastNode);
        }

        [Fact]
        public void Test_Constructor_With_Initial_Value()
        {
            Core.DoublyLinkedList<int> doublyLinkList = new Core.DoublyLinkedList<int>(2020);
            Assert.NotEmpty(doublyLinkList);
            Assert.Equal(1, doublyLinkList.Count);
            Assert.Equal(2020, doublyLinkList.FirstNode.Value);
            Assert.Equal(doublyLinkList.FirstNode, doublyLinkList.LastNode);
            Assert.Equal(doublyLinkList.FirstNode.Value, doublyLinkList.LastNode.Value);
        }

        [Fact]
        public void Test_Add_First()
        {
            Core.DoublyLinkedList<int> doublyLinkedList = new Core.DoublyLinkedList<int>(100);
            Assert.NotEmpty(doublyLinkedList);

            doublyLinkedList.AddFirst(200);
            Assert.Equal(2, doublyLinkedList.Count);
            Assert.Equal(200, doublyLinkedList.FirstNode.Value);
            Assert.Equal(100, doublyLinkedList.LastNode.Value);
            Assert.NotEqual(doublyLinkedList.FirstNode, doublyLinkedList.LastNode);
        }

        [Fact]
        public void Test_Add_Last()
        {
            Core.DoublyLinkedList<int> doublyLinkedList = new Core.DoublyLinkedList<int>(10);
            Assert.NotEmpty(doublyLinkedList);

            doublyLinkedList.AddLast(20);
            Assert.Equal(2, doublyLinkedList.Count);
            Assert.Equal(10, doublyLinkedList.FirstNode.Value);
            Assert.Equal(20, doublyLinkedList.LastNode.Value);
            Assert.NotEqual(doublyLinkedList.FirstNode, doublyLinkedList.LastNode);
        }
    }
}
