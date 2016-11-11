namespace DataStructures.Trees
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Text;

    public class AVLTree<T> where T : IComparable<T>
    {
        public AVLTree()
        {

        }

        public AVLNode<T> Root { get; private set; }

        public void Add(T value)
        {
            Root = Insert(value, Root);
        }

        public IEnumerable<T> EnumerateByLevels()
        {
            Queue<AVLNode<T>> queue = new Queue<AVLNode<T>>();
            if (Root == null) yield break;
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current.Value;
                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }
        private AVLNode<T> Insert(T value, AVLNode<T> node)
        {
            if (ReferenceEquals(null, node))
            {
                node = new AVLNode<T>(value);
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                node.Left = Insert(value, node.Left);
                if (!node.IsBalanced)
                {
                    if (node.Left.Value.CompareTo(value) > 0)
                        node = rotateWithLeftChild(node);
                    else
                        node = doubleWithLeftChild(node);
                }

            }
            else if (node.Value.CompareTo(value) < 0)
            {
                node.Right = Insert(value, node.Right);
                if (!node.IsBalanced)
                {
                    if (node.Right.Value.CompareTo(value) < 0)
                        node = rotateWithRightChild(node);
                    else
                        node = doubleWithRightChild(node);
                }
            }
            node.Weight = Math.Max(node.LeftSize, node.RightSize) + 1;
            return node;
        }

        private AVLNode<T> doubleWithRightChild(AVLNode<T> k1)
        {
            k1.Right = rotateWithLeftChild(k1.Right);
            return rotateWithRightChild(k1);
        }

        private AVLNode<T> doubleWithLeftChild(AVLNode<T> node)
        {
            node.Left = rotateWithLeftChild(node.Left);
            return rotateWithLeftChild(node);
        }

        private AVLNode<T> rotateWithRightChild(AVLNode<T> node)
        {
            AVLNode<T> k2 = node.Right;
            node.Right = k2.Left;
            k2.Left = node;
            node.Weight = Math.Max((node.LeftSize), (node.RightSize)) + 1;
            k2.Weight = Math.Max((k2.RightSize), node.Weight) + 1;
            return k2;
        }

        private AVLNode<T> rotateWithLeftChild(AVLNode<T> node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;
            left.Weight = Math.Max(node.LeftSize, node.RightSize) + 1;
            node.Weight = Math.Max(node.LeftSize, left?.Weight ?? 0) + 1;
            return left;

        }

    }

    public class AVLNode<T> where T : IComparable<T>
    {
        public bool IsBalanced => Math.Abs(LeftSize - RightSize) <= 1;
        public int LeftSize => Left?.Weight ?? 0;
        public int RightSize => Right?.Weight ?? 0;
        public int Weight { get; internal set; }
        public T Value { get; internal set; }
        public AVLNode<T> Right { get; set; }
        public AVLNode<T> Left { get; set; }
        internal AVLNode(T value, AVLNode<T> right = null, AVLNode<T> left = null)
        {
            Right = right;
            Left = left;
            Value = value;
        }
    }
}
