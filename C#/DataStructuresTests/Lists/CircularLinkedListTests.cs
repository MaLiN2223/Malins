namespace DataStructuresTests
{
    using DataStructures.Lists;
    using NUnit.Framework;

    [TestFixture]
    public class CircularLinkedListTests
    {
        CircularLinkedList<int> linkedList;
        [OneTimeSetUp]
        public void Init()
        {
            linkedList = new CircularLinkedList<int>();
        }
        [Test]
        public void Empty()
        {
            Assert.AreEqual(0, linkedList.Count);
            Assert.AreEqual(null, linkedList.First);
            Assert.IsFalse(linkedList.Contains(0));
        }
    }
}
