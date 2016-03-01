namespace DataStructuresTests.Trees
{
    using DataStructures.Trees;
    using NUnit.Framework;
    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    [TestFixture]
    public class SplayTreesTests
    {
        [Test]
        public void ZigTest()
        {
            SplayTree<int> tree = new SplayTree<int>();
            for (int i = 9; i >= 0; --i)
            {
                tree.Insert(i);
            }
            Assert.AreEqual(0, tree.Root.Value);
            var head = tree.Root;
            for (int i = 0; i <= 9; ++i)
            {
                Assert.AreEqual(i, head.Value);
                head = head.Right;
            }
        }

        [Test]
        public void ZigZagTest()
        {
            SplayTree<int> tree = new SplayTree<int>();
            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(13);
            Assert.AreEqual(13, tree.Root.Value);
            Assert.AreEqual(15, tree.Root.Right.Value);
            Assert.AreEqual(10, tree.Root.Left.Value);

        }

        [Test]
        public void AllOpsTest()
        {

            SplayTree<int> tree = new SplayTree<int>();
            tree.Insert(10);
            Assert.AreEqual(10, tree.Root.Value);
            tree.Insert(15);
            Assert.AreEqual(15, tree.Root.Value);
            tree.Insert(13);
            Assert.AreEqual(13, tree.Root.Value);
            Assert.AreEqual(10, tree.Root.Left.Value);
            Assert.AreEqual(15, tree.Root.Right.Value);
            tree.Insert(16);
            Assert.AreEqual(16, tree.Root.Value);
            Assert.AreEqual(15, tree.Root.Left.Value);
            Assert.AreEqual(13, tree.Root.Left.Left.Value);
            Assert.AreEqual(10, tree.Root.Left.Left.Left.Value);
            tree.Insert(18);
            Assert.AreEqual(18, tree.Root.Value);
            Assert.AreEqual(16, tree.Root.Left.Value);
            Assert.AreEqual(15, tree.Root.Left.Left.Value);
            Assert.AreEqual(13, tree.Root.Left.Left.Left.Value);
            Assert.AreEqual(10, tree.Root.Left.Left.Left.Left.Value);
            tree.Insert(17);
            Assert.AreEqual(17, tree.Root.Value);
            Assert.AreEqual(18, tree.Root.Right.Value);
            Assert.AreEqual(16, tree.Root.Left.Value);
            Assert.AreEqual(15, tree.Root.Left.Left.Value);
            Assert.AreEqual(13, tree.Root.Left.Left.Left.Value);
            Assert.AreEqual(10, tree.Root.Left.Left.Left.Left.Value);
            tree.Insert(14);
            Assert.AreEqual(14, tree.Root.Value);
            Assert.AreEqual(13, tree.Root.Left.Value);
            Assert.AreEqual(10, tree.Root.Left.Left.Value);
            Assert.AreEqual(16, tree.Root.Right.Value);
            Assert.AreEqual(15, tree.Root.Right.Left.Value);
            Assert.AreEqual(17, tree.Root.Right.Right.Value);
            Assert.AreEqual(18, tree.Root.Right.Right.Right.Value);
            tree.Insert(12);
            Assert.AreEqual(12, tree.Root.Value);
            Assert.AreEqual(10, tree.Root.Left.Value);
            Assert.AreEqual(14, tree.Root.Right.Value);
            Assert.AreEqual(13, tree.Root.Right.Left.Value);
            Assert.AreEqual(16, tree.Root.Right.Right.Value);
            Assert.AreEqual(15, tree.Root.Right.Right.Left.Value);
            Assert.AreEqual(17, tree.Root.Right.Right.Right.Value);
            Assert.AreEqual(18, tree.Root.Right.Right.Right.Right.Value);


        }
    }
}
