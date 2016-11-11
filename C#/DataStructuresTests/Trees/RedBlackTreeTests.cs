using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Trees
{
    using DataStructures.Trees;

    [TestClass]
    public class RedBlackTreeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(0);
            tree.Insert(-1);
            tree.Insert(11);
            tree.Insert(12);
            tree.Insert(21);
            tree.Insert(23);
            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(16);
            tree.Insert(25); 

        }
    }
}
