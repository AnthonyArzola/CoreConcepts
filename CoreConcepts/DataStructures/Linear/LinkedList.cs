using System.Collections;
using System.Collections.Generic;

namespace CoreConcepts.DataStructures.Linear
{
    public class LinkedList<T> : ICollection<T>
    {
        #region Data Members

        public LinkNode<T> First { get; private set; }

        public LinkNode<T> Last { get; private set; }

        public int Count { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create new linked list.
        /// </summary>
        public LinkedList()
        {

        }

        /// <summary>
        /// Create new linked list and initialize with value.
        /// </summary>
        /// <param name="value">Initial value.</param>
        public LinkedList(T value)
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
            AddFirst(new LinkNode<T>(value));
        }

        /// <summary>
        /// Add node to beginning of list.
        /// </summary>
        /// <param name="node"></param>
        public void AddFirst(LinkNode<T> node)
        {
            // Save previous First
            LinkNode<T> previousFirst = First;

            // Make node new First
            First = node;

            // Point new First to old First
            First.Next = previousFirst;

            // If this is a new linked list,
            // First and Last are the same
            if (Last == null)
            {
                Last = First;
            }

            Count++;
        }

        /// <summary>
        /// Add value to end of the list.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void AddLast(T value)
        {
            AddLast(new LinkNode<T>(value));
        }

        /// <summary>
        /// Add node to end of the list.
        /// </summary>
        /// <param name="node"></param>
        public void AddLast(LinkNode<T> node)
        {
            if (First == null && Last == null)
            {
                First = node;
                Last = First;
            }
            else
            {
                Last.Next = node;
                Last = node;
            }

            Count++;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
                return;

            First = First.Next;
            Count--;

            if (Count == 0)
                Last = null;
        }

        public void RemoveLast()
        {
            if (Count > 0)
            {
                if (Count == 1)
                {
                    First = Last = null;
                }
                else
                {
                    LinkNode<T> node = First;
                    // Find second to last node
                    while (node.Next != Last)
                    {
                        node = node.Next;
                    }

                    node.Next = null;
                    Last = node;
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
                LinkNode<T> previousNode = null;
                LinkNode<T> currenNode = First;

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
                                Last = previousNode;
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
            First = null;
            Last = null;
            Count = 0;
        }

        bool ICollection<T>.Contains(T item)
        {
            LinkNode<T> node = First;
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
            LinkNode<T> node = First;
            while (node.Next != null)
            {
                array[arrayIndex] = node.Value;
                arrayIndex++;
                node = node.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkNode<T> node = First;
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
