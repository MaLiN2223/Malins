using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Trees
{
    using DataStructures.Trees;

    [TestClass]
    public class AVLTests
    {
        [TestMethod]
        public void First()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(1);
            tree.Add(0);
            tree.Add(2);
            tree.Add(5);
            tree.Add(7);
            tree.Add(19);
            tree.Add(6);
            tree.Add(8);
            tree.Add(4);
            Assert.AreEqual(tree.Root.Value, 5);
        }
    }
}
