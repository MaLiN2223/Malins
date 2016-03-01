namespace DataStructures.Trees
{
    public class BinaryNode<T, TK>
    {
        public BinaryNode(T value, TK key)
        {
            Value = value;
            Key = key;
        }
        public T Value { get; private set; }
        public TK Key { get; private set; }
        private BinaryNode<T, TK> left;
        private BinaryNode<T, TK> right;
        public BinaryNode<T, TK> Left
        {
            get { return left; }
            set
            {
                left = value;
                if (left != null)
                    left.Parent = this;
            }
        }

        public BinaryNode<T, TK> Right
        {
            get { return right; }
            set
            {
                right = value;
                if (right != null)
                    right.Parent = this;
            }
        }
        public BinaryNode<T, TK> Parent { get; set; }
    }
}
