using System.Collections;
using System.Collections.Generic;

namespace CoreConcepts.DataStructures.Linear
{
    public class Queue<T>: IEnumerable<T>
    {
        #region "Data Members"

        private System.Collections.Generic.LinkedList<T> LinkedList = new System.Collections.Generic.LinkedList<T>();

        #endregion

        #region "Public Properties"

        /// <summary>
        /// First item in the queue.
        /// </summary>
        public T FirstItem => LinkedList.First.Value;

        /// <summary>
        /// Last item in the queue.
        /// </summary>
        public T LastItem => LinkedList.Last.Value;

        /// <summary>
        /// Number of items in the queue.
        /// </summary>
        public int Count => LinkedList.Count;

        #endregion

        #region "Public Methods"

        /// <summary>
        /// Add element to back of the queue.
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            LinkedList.AddLast(item);
        }

        /// <summary>
        /// Remove first element in the queue and return it.
        /// </summary>
        /// <returns>Element of type T.</returns>
        public T Dequeue()
        {
            if (LinkedList.Count > 0)
            {
                T firstItem = LinkedList.First.Value;
                LinkedList.RemoveFirst();
                return firstItem;
            }
            else
            {
                throw new System.Exception("Unable to dequeue empty queue.");
            }
        }

        public void Clear()
        {
            LinkedList.Clear();
        }

        #endregion

        #region "IEnumerable Methods"

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => LinkedList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => LinkedList.GetEnumerator();

        #endregion
    }
}
