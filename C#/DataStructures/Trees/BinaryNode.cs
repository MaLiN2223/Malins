namespace DataStructures.Trees
{
    public class BinaryNode<T>
    {
        public BinaryNode(T value)
        {
            Value = value;
        }
        public T Value { get; private set; } 
        private BinaryNode<T> left;
        private BinaryNode<T> right;
        public BinaryNode<T> Left
        {
            get { return left; }
            set
            {
                left = value;
                if (left != null)
                    left.Parent = this;
            }
        }

        public BinaryNode<T> Right
        {
            get { return right; }
            set
            {
                right = value;
                if (right != null)
                    right.Parent = this;
            }
        }
        public BinaryNode<T> Parent { get; set; }
    }
}
