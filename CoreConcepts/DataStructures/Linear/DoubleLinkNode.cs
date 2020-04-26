namespace CoreConcepts.DataStructures.Linear
{
    public class DoubleLinkNode<T>
    {
        #region Data Members

        public T Value { get; set; }

        public DoubleLinkNode<T> Next { get; set; }

        public DoubleLinkNode<T> Previous { get; set; }

        #endregion

        #region Contructors

        public DoubleLinkNode(T value)
        {
            Value = value;
        }

        #endregion
    }
}
