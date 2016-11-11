
namespace DataStructures.Trees
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Dynamic;
    using System.Xml.Linq;

    public class RedBlackTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private static readonly bool BLACK = true;
        private static readonly bool RED = false;

        public Node<T> Head = Node<T>.GetNull(null);
        public RedBlackTree() { }
        public RedBlackTree(Node<T> head)
        {
            Head = head;
        }
        public RedBlackTree(T value)
        {
            Head = new Node<T>(true, value, null);
        }

        public void Insert(T value)
        {
            Head =
                Head.IsNull ?
                new Node<T>(true, value, null) :
                Insert(Head, value);
        }

        public Node<T> Insert(Node<T> node, T value)
        {
            if (node.IsNull)
                return Node<T>.GetNull(node);
            int comp = value.CompareTo(node.Data);
            if (comp > 0)
                node.Right = Insert(node.Right, value);
            if (comp < 0)
                node.Left = Insert(node.Left, value);
            if (!node.Right.Color && node.Left.Color)
                node = rotateLeft(node);
            if (!node.Right.Color && !node.Left.Left.Color)
                node = rotateRight(node);
            if (!node.Right.Color && !node.Right.Color)
                swapColor(node);
            return node;
        }

        private void swapColor(Node<T> h)
        {
            h.Color = !h.Color;
            h.Left.Color = !h.Left.Color;
            h.Right.Color = !h.Right.Color;
        }

        private Node<T> rotateLeft(Node<T> h)
        {
            Node<T> x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = x.Left.Color;
            x.Left.Color = RED;
            return x;
        }
        private Node<T> rotateRight(Node<T> h)
        {
            Node<T> x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = x.Right.Color;
            x.Right.Color = RED;
            return x;

        }

        private Node<T> InsertBST(T value)
        {
            var n = Find(value);
            Node<T> node = new Node<T>(false, value, n, null, null);
            return node;
        }
        /// <summary>
        /// Returns RedBlackTreeNode with value, if not found returns lastest checked
        /// </summary> 
        public Node<T> Find(T value)
        {
            var head = Head;
            Node<T> prev = null;
            while (head != null && head.Data.CompareTo(value) != 0)
            {
                prev = head;
                head = head.Data.CompareTo(value) < 0 ? head.Left : head.Right;
            }
            return head ?? prev;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Head == null)
                yield break;
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(Head);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Data;
                if (!node.Left.IsNull)
                    stack.Push(node.Left);
                if (!node.Right.IsNull)
                    stack.Push(node.Right);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Node<T> : INullable where T : IComparable<T>
    {
        private static readonly bool BLACK = true;
        private static readonly bool RED = false;
        /// <summary>
        /// NULL node
        /// </summary>
        /// <param name="parent"></param>
        private Node(Node<T> parent)
        {
            Color = BLACK;
            IsNull = true;
            Parent = parent;
        }

        public static Node<T> GetNull(Node<T> parent)
        {
            return new Node<T>(parent);
        }
        public Node(bool color, T value, Node<T> parent, Node<T> left = null, Node<T> right = null)
        {
            Color = color;
            Left = left;
            Parent = parent;
            Right = right;
            IsNull = false;
            Data = value;
        }
        public T Data { get; }
        /// <summary>
        /// Is black
        /// </summary>
        public bool Color { get; set; }
        public Node<T> Right { get; internal set; }
        public Node<T> Left { get; internal set; }
        public Node<T> Parent { get; }
        public bool IsNull { get; }
        public Node<T> Uncle
        {
            get
            {
                if (Parent?.Parent != null)
                    return Parent.Data.CompareTo(Parent.Parent.Data) < 0 ? Parent.Parent.Right : Parent.Parent.Left;
                throw new NullReferenceException();
            }
        }

    }
}
