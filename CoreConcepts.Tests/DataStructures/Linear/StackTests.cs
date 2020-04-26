using Core = CoreConcepts.DataStructures.Linear;

using Xunit;

namespace CoreConcepts.Tests.DataStructures.Linear
{
    public class StackTests
    {
        [Fact]
        public void Test_Default_Constructor()
        {
            Core.Stack<int> stack = new Core.Stack<int>();
            Assert.Empty(stack);
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Test_Constructor_With_Initial_Value()
        {
            Core.Stack<int> stack = new Core.Stack<int>(5);
            Assert.NotEmpty(stack);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Test_Push()
        {
            Core.Stack<int> stack = new Core.Stack<int>();
            int itemsToPush = 5;
            for (int i = 0; i < itemsToPush; i++)
            {
                stack.Push(i);
            }
            Assert.Equal(itemsToPush, stack.Count);
        }

        [Fact]
        public void Test_Peek()
        {
            Core.Stack<int> stack = new Core.Stack<int>();
            int pushedValue = 5;
            stack.Push(pushedValue);
            Assert.Equal(pushedValue, stack.Peek());
        }

        [Fact]
        public void Test_Pop()
        {
            Core.Stack<int> stack = new Core.Stack<int>();
            int itemsToPush = 5;
            for (int i = 1; i <= itemsToPush; i++)
            {
                stack.Push(i);
            }
            for (int i = itemsToPush; i > 0; i--)
            {
                int value = stack.Pop();
                Assert.Equal(i, value);
            }

            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Test_Clear()
        {
            Core.Stack<int> stack = new Core.Stack<int>();
            int itemsToPush = 5;
            for (int i = 0; i < itemsToPush; i++)
            {
                stack.Push(i);
            }
            stack.Clear();

            Assert.Equal(0, stack.Count);
        }

    }
}
