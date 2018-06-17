namespace CoreConcepts.DataStructures.Linear
{
    public class LinkNode<T>
    {
        #region Data Members

        public T Value { get; set; }

        public LinkNode<T> Next { get; set; }

        #endregion

        #region Contructors

        public LinkNode(T value)
        {
            Value = value;
        }

        #endregion
    }
}
