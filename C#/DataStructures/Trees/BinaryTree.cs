namespace DataStructures.Trees
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq; 

    public abstract class BinaryTree<T> : IEnumerable<T>
    {
        public abstract BinaryNode<T> Root { get; protected set; }
        public abstract int Count { get; protected set; }
        public abstract bool Contains(T key);
        public abstract BinaryNode<T> Find(T key);
        public IEnumerable<T> GetPreorderTraversal()
        {
            return this.ToList();
        }

        public void Clear()
        {
            Root = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var stack = new Stack<BinaryNode<T>>();
            stack.Push(Root);
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (item != null)
                {
                    yield return item.Value;
                    if (item.Right != null)
                        stack.Push(item.Right);
                    if (item.Left != null)
                        stack.Push(item.Left);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
