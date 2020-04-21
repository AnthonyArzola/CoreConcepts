using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreConcepts.DataStructures.Linear
{
    public class Stack<T>: IEnumerable<T>
    {
        private System.Collections.Generic.LinkedList<T> List = new System.Collections.Generic.LinkedList<T>();

        #region "Public methods" 

        public bool Push(T item)
        {
            LinkedListNode<T> addedItem = List.AddFirst(item);
            return (addedItem != null);
        }

        public T Peek()
        {
            if (List.Count <= 0)
            {
                throw new Exception("Unable to peek. Stack is empty");
            }
            return List.First.Value;
        }

        public T Pop()
        {
            if (List.Count <= 0)
            {
                throw new Exception("Unable to pop item. Stack is empty.");
            }

            T topItem = List.First.Value;
            List.RemoveFirst();
            return topItem;
        }

        public void Clear()
        {
            List.Clear();
        }

        public int Count()
        {
            return List.Count;
        }

        #endregion

        #region "IEnumerable Interface methods"

        public IEnumerator<T> GetEnumerator() => List.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => List.GetEnumerator();

        #endregion
    }
}
