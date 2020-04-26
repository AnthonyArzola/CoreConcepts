using System.Collections;
using System.Collections.Generic;

namespace CoreConcepts.DataStructures.Linear
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        #region Data Members

        public DoubleLinkNode<T> FirstNode { get; private set; }

        public DoubleLinkNode<T> LastNode { get; private set; }

        public int Count { get; private set; }

        #endregion

        #region Constructors

        public DoublyLinkedList()
        {
        }

        public DoublyLinkedList(T value)
        {
            AddFirst(value);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add value to beginning of list.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void AddFirst(T value)
        {
            AddFirst(new DoubleLinkNode<T>(value));
        }

        /// <summary>
        /// Add node to beginning of list.
        /// </summary>
        /// <param name="node"></param>
        private void AddFirst(DoubleLinkNode<T> node)
        {
            // Copy first node
            DoubleLinkNode<T> previousFirst = FirstNode;

            // Make incoming `node` first
            FirstNode = node;

            // New first node will now point to previous first node
            FirstNode.Next = previousFirst;

            // If this is a new linked list,
            // First and Last are the same
            if (LastNode == null)
            {
                LastNode = FirstNode;
            }
            else
            {
                previousFirst.Previous = FirstNode;
            }

            Count++;
        }

        /// <summary>
        /// Add value to end of the list.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void AddLast(T value)
        {
            AddLast(new DoubleLinkNode<T>(value));
        }

        /// <summary>
        /// Add node to end of the list.
        /// </summary>
        /// <param name="node"></param>
        private void AddLast(DoubleLinkNode<T> node)
        {
            if (FirstNode == null && LastNode == null)
            {
                // New linked list. Incoming `node` is First and Last
                FirstNode = node;
                LastNode = FirstNode;
            }
            else
            {
                // Point last node to incoming `node`. Set `node` as Last.
                LastNode.Next = node;
                node.Previous = LastNode;
                LastNode = node;
            }
            Count++;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
                return;

            // Update First pointer
            FirstNode = FirstNode.Next;
            FirstNode.Previous = null;
            Count--;

            if (Count == 0)
                LastNode = null;
        }

        public void RemoveLast()
        {
            if (Count > 0)
            {
                if (Count == 1)
                {
                    FirstNode = LastNode = null;
                }
                else
                {
                    // Get second to last node
                    DoubleLinkNode<T> node = LastNode.Previous;
                    node.Next = null;
                    LastNode = node;
                }

                Count--;
            }
        }

        #endregion

        #region ICollection interface methods

        void ICollection<T>.Add(T item)
        {
            AddFirst(item);
        }

        bool ICollection<T>.Remove(T item)
        {
            if (Count == 0)
            {
                return false;
            }
            else
            {
                DoubleLinkNode<T> previousNode = null;
                DoubleLinkNode<T> currenNode = FirstNode;

                while (currenNode != null)
                {
                    if (currenNode.Value.Equals(item))
                    {
                        // Match found
                        if (previousNode != null)
                        {
                            // PreviousNode is set, we are past first node

                            // Change pointers (disconnect previous -> current)
                            previousNode.Next = currenNode.Next;

                            // If current node was last node, previous becomes new Last
                            if (currenNode.Next == null)
                            {
                                LastNode = previousNode;
                            }

                            Count--;
                        }
                        else
                        {
                            // Previous node never set, remove first node
                            RemoveFirst();
                        }

                        return true;
                    }

                    // Move pointers
                    previousNode = currenNode;
                    currenNode = currenNode.Next;
                }
                return false;
            }
        }

        void ICollection<T>.Clear()
        {
            FirstNode = null;
            LastNode = null;
            Count = 0;
        }

        bool ICollection<T>.Contains(T item)
        {
            DoubleLinkNode<T> node = FirstNode;
            while (node.Next != null)
            {
                if (node.Value.Equals(item))
                    return true;

                node = node.Next;
            }

            return false;
        }

        int ICollection<T>.Count => Count;

        bool ICollection<T>.IsReadOnly => false;

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            DoubleLinkNode<T> node = FirstNode;
            while (node.Next != null)
            {
                array[arrayIndex] = node.Value;
                arrayIndex++;
                node = node.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleLinkNode<T> node = FirstNode;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        #endregion

    }
}
