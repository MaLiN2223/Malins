using System;
namespace DataStructures.Trees
{
    using System.Collections.Generic;

    public class SplayTree<T> : BinaryTree<T>
    {
        public SplayTree()
        {
            comparer = Comparer<T>.Default;
        }
        public SplayTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        private readonly IComparer<T> comparer;

        public override BinaryNode<T> Find(T key)
        {
            var head = Root;
            BinaryNode<T> prev = null;
            while (head != null)
            {
                var comparedInt = comparer.Compare(head.Value, key);
                if (comparedInt == 0)
                {
                    Splay(head);
                    return head;
                }
                prev = head;
                head = comparedInt < 0 ? head.Right : head.Left;
            }
            Splay(prev);
            return null;
        }
        public override BinaryNode<T> Root { get; protected set; }
        public override int Count { get; protected set; }
        public override bool Contains(T key)
        {
            return Find(key) != null;
        }
        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new BinaryNode<T>(value);
                Count = 1;
            }
            else
                DoInsert(value);
        }

        public void Remove(T value)
        {
            var node = Find(value);
            if (node != null)
            {
                doRemove(node);
            }
            else
            {
                throw new ArgumentException($"{nameof(value)} does not exist in set.");
            }
        }

        private void doRemove(BinaryNode<T> node)
        {
            var parent = node.Parent;
            bool nodeIsRoot = (parent == null);
            bool nodeIsRightChild = ReferenceEquals(parent?.Right, node);
            bool leftIsNull = (node.Left == null);
            bool rightIsNull = (node.Right == null);
            if (leftIsNull && rightIsNull)
            {
                if (!nodeIsRoot)
                {
                    if (nodeIsRightChild)
                        parent.Right = null;
                    else
                        parent.Left = null;
                }
                else
                {
                    Root = null;
                }
            }
            else if (leftIsNull)
            {
                if (nodeIsRoot)
                {
                    Root = node.Right;
                    node.Right.Parent = null;
                }
                else // parent!=null
                {
                    if (nodeIsRightChild)
                        parent.Right = node.Right;
                    else
                        parent.Left = node.Right;
                }
            }
            else if (rightIsNull)
            {
                if (nodeIsRoot)
                {
                    Root = node.Left;
                    node.Left.Parent = null;
                }
                else // parent!=null
                {
                    if (nodeIsRightChild)
                        parent.Right = node.Left;
                    else
                        parent.Left = node.Left;
                }
            }
            else // both children are !=null
            {
                var newNode = DeleteMax(node.Left);
                if (parent == null)
                {
                    Root = newNode;
                    newNode.Parent = null;
                }
                else if (nodeIsRightChild)
                {
                    parent.Right = newNode;
                }
                else
                {
                    parent.Left = newNode;
                }
                newNode.Left = node.Left;
                newNode.Right = node.Right;
                if (newNode.Parent != null)
                    Splay(newNode.Parent);
            }
        }

        public BinaryNode<T> DeleteMax(BinaryNode<T> node)
        {
            var current = node;
            while (current.Right != null)
            {
                current = current.Right;
            }
            if (current.Parent != null)
            {
                current.Parent.Right = current.Left;
            }
            else // current is root
            {
                Root = current.Left;
                current.Left.Parent = null;
            }
            return current;

        }

        private void DoInsert(T value)
        {
            var head = Root;
            var item = new BinaryNode<T>(value);
            while (head != null)
            {
                int comparedInt = comparer.Compare(head.Value, value);
                if (comparedInt > 0)
                {
                    if (head.Left == null)
                    {
                        head.Left = item;
                        Splay(item);
                        Count++;
                        break;
                    }
                    head = head.Left;
                }
                else if (comparedInt < 0)
                {
                    if (head.Right == null)
                    {
                        head.Right = item;
                        Splay(item);
                        Count++;
                        break;
                    }
                    head = head.Right;
                }
                else if (comparedInt == 0)
                {
                    //IGNORE
                    break;
                }
            }
        } 
        private void Splay(BinaryNode<T> node)
        {
            if (node == null)
                return;

            while (node.Parent != null)
            {
                bool splayed = false;
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
        private void Zig(BinaryNode<T> node)
        {
            if (Root.Left == node)
            {
                var right = node.Right;
                var oldRoot = Root;
                Root = node;
                node.Parent = null;
                Root.Right = oldRoot;
                oldRoot.Left = right;
            }
            else // Root.Right == node
            {
                var left = node.Left;
                var oldRoot = Root;
                Root = node;
                node.Parent = null;
                Root.Left = oldRoot;
                oldRoot.Right = left;
            }

        }

        private void ZigZig(BinaryNode<T> node, bool isLeft)
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

        private void ZigZag(BinaryNode<T> node, bool isLeft)
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
                //if (Root.Left != null)
                //    Root.Left.Parent = node;
                //if (Root.Right != null)
                //    Root.Right.Parent = node;
                Root = node;
                node.Parent = null;
            }
            if (isLeft) // node is left child of right child of some grandparent
            {
                node.Left = grandParent;
                node.Right = parent;
                grandParent.Right = left;
                parent.Left = right;
            }
            else // node is right child of left child of grandparent
            {
                node.Left = parent;
                node.Right = grandParent;
                parent.Right = left;
                grandParent.Left = right;
            }
        }

    }
}
