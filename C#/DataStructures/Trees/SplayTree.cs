using System;
namespace DataStructures.Trees
{

    public class SplayTree<T, TK> where TK : IComparable<TK>
    {
        private BinaryNode<T, TK> root;

        public BinaryNode<T, TK> Root
        {
            get { return root; }
            private set
            {
                root = value;
                root.Parent = null;
            }
        }
        public SplayTree() { }

        public bool Contains(TK key)
        {
            return Find(key) != null;
        }

        public BinaryNode<T, TK> Find(TK key)
        {
            var head = Root;
            BinaryNode<T, TK> prev = null;
            while (head != null)
            {
                if (head.Key.CompareTo(key) == 0)
                {
                    Splay(head);
                    return head;
                }
                prev = head;
                head = head.Key.CompareTo(key) < 0 ? head.Right : head.Left;
            }
            Splay(prev);
            return null;
        }
        public void Insert(T value, TK key)
        {
            if (Root == null)
                Root = new BinaryNode<T, TK>(value, key);
            else
                DoInsert(value, key);
        }

        private void DoInsert(T value, TK key)
        {
            var head = Root;
            var item = new BinaryNode<T, TK>(value, key);
            while (head != null)
            {
                if (head.Key.CompareTo(key) > 0)
                {
                    if (head.Left == null)
                    {
                        head.Left = item;
                        Splay(item);
                        break;
                    }
                    head = head.Left;
                }
                else if (head.Key.CompareTo(key) < 0)
                {
                    if (head.Right == null)
                    {
                        head.Right = item;
                        Splay(item);
                        break;
                    }
                    head = head.Right;
                }
            }
        }

        private void Splay(BinaryNode<T, TK> node)
        {
            if (node == null)
                return;

            bool splayed = false;
            while (node.Parent != null)
            {
                if (node.Parent == Root)
                {
                    Zig(node);
                    splayed = true;
                }
                else if (node.Parent.Parent != null)
                {
                    bool nodeIsRightZigZag = node.Parent.Right == node && node.Parent.Parent.Left == node.Parent;
                    bool nodeIsLeftZigZag = node.Parent.Left == node && node.Parent.Parent.Right == node.Parent;
                    bool nodeIsLeftZigZig = node.Parent.Left == node && node.Parent.Parent.Left == node.Parent;
                    bool nodeIsRightZigZig = node.Parent.Right == node && node.Parent.Parent.Right == node.Parent;
                    if (node.Parent?.Parent != null && (nodeIsLeftZigZag || nodeIsRightZigZag))
                    {
                        ZigZag(node, nodeIsLeftZigZag);
                        splayed = true;
                    }
                    else if (node.Parent?.Parent != null && (nodeIsLeftZigZig || nodeIsRightZigZig))
                    {
                        ZigZig(node, nodeIsLeftZigZig);
                        splayed = true;
                    }
                }
                if (!splayed)
                    break;
            }
        }
        /// <summary>
        /// Node has parent who is Root
        /// </summary> 
        /// <returns></returns>
        private void Zig(BinaryNode<T, TK> node)
        {
            if (Root.Left == node)
            {
                var right = node.Right;
                var oldRoot = Root;
                Root = node;
                Root.Right = oldRoot;
                oldRoot.Left = right;
            }
            else // Root.Right == node
            {
                var left = node.Left;
                var oldRoot = Root;
                Root = node;
                Root.Left = oldRoot;
                oldRoot.Right = left;
            }

        }

        private void ZigZig(BinaryNode<T, TK> node, bool isLeft)
        {
            var left = node.Left;
            var right = node.Right;
            var parent = node.Parent;
            var grandParent = parent.Parent;
            var grandParentParent = grandParent.Parent;
            if (grandParentParent != null)
            {
                if (grandParentParent.Left == grandParent)
                {
                    grandParentParent.Left = node;
                }
                else
                {
                    grandParentParent.Right = node;
                }
            }
            else // grandParent == Root
            {
                Root = node;
                node.Parent = null;
            }
            if (isLeft)
            {
                node.Right = parent;
                parent.Left = right;
                grandParent.Left = parent.Right;
                parent.Right = grandParent;
            }
            else
            {
                node.Left = parent;
                parent.Right = left;
                grandParent.Right = parent.Left;
                parent.Left = grandParent;
            }
        }

        private void ZigZag(BinaryNode<T, TK> node, bool isLeft)
        {
            var left = node.Left;
            var right = node.Right;
            var parent = node.Parent;
            var grandParent = parent.Parent;
            var grandParentParent = grandParent.Parent;
            if (grandParentParent != null)
            {
                if (grandParentParent.Left == grandParent)
                {
                    grandParentParent.Left = node;
                }
                else
                {
                    grandParentParent.Right = node;
                }
            }
            else // grandParent == Root
            {
                if (Root.Left != null)
                    Root.Left.Parent = node;
                if (Root.Right != null)
                    Root.Right.Parent = node;
                Root = node;
                node.Parent = null;
            }
            if (isLeft) // node is left child of right child of some node
            {
                node.Right = grandParent;
                node.Left = parent;
                grandParent.Right = left;
                parent.Right = right;
            }
            else // node is right child of left child of grandparent
            {
                node.Left = parent;
                parent.Right = left;
                node.Right = grandParent;
                grandParent.Left = right;
            }
        }
    }
}
