using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreConcepts.DataStructures.Linear
{
    public class Stack<T>: IEnumerable<T>
    {
        #region "Data Members"

        private System.Collections.Generic.LinkedList<T> List = new System.Collections.Generic.LinkedList<T>();

        public int Count => List.Count;

        #endregion

        #region "Public methods"

        public bool Push(T item)
        {
            LinkedListNode<T> addedItem = List.AddLast(item);
            return (addedItem != null);
        }

        public T Peek()
        {
            if (List.Count <= 0)
            {
                throw new Exception("Unable to peek. Stack is empty");
            }
            return List.Last.Value;
        }

        public T Pop()
        {
            if (List.Count <= 0)
            {
                throw new Exception("Unable to pop item. Stack is empty.");
            }

            T topItem = List.Last.Value;
            List.RemoveLast();
            return topItem;
        }

        public void Clear()
        {
            List.Clear();
        }

        #endregion

        #region "IEnumerable Interface methods"

        public IEnumerator<T> GetEnumerator() => List.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => List.GetEnumerator();

        #endregion
    }
}
