namespace DataStructuresTests.Lists
{
    using System.Collections.Generic;
    using System.Linq;
    using DataStructures.Lists;
    using NUnit.Framework;

    [TestFixture]
    public class CircularLinkedListTests
    {
        [Test]
        public void Empty()
        {
            var linkedList = new CircularLinkedList<int>();
            Assert.AreEqual(0, linkedList.Count);
            Assert.AreEqual(null, linkedList.First);
            Assert.IsFalse(linkedList.Contains(0));
        }
        [TestCase(new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        public void Adding(int[] data)
        {
            var linkedList = new CircularLinkedList<int>();
            int count = 0;
            foreach (var item in data)
            {
                linkedList.Add(item);
                count++;
            }
            Assert.AreEqual(count, linkedList.Count);
            Assert.AreNotEqual(null, linkedList.First);
            var enumerator = data.Reverse().GetEnumerator();
            enumerator.MoveNext();
            foreach (var item in linkedList)
            {
                Assert.AreEqual(enumerator.Current, item);
                enumerator.MoveNext();
            }
        }

        [TestCase(new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4 })]
        public void Clearing(IEnumerable<int> data)
        {
            var linkedList = new CircularLinkedList<int>();
            foreach (var item in data)
            {
                linkedList.Add(item);
            }
            linkedList.Clear();
            Assert.AreEqual(0, linkedList.Count);
            Assert.AreEqual(null, linkedList.First);
        }
        [TestCase(new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        public void AddLast(int[] data)
        {
            var linkedList = new CircularLinkedList<int>(data);
            var enumerator = data.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(data.Length, linkedList.Count);
            Assert.AreNotEqual(null, linkedList.First);
            foreach (var item in linkedList)
            {
                Assert.AreEqual(enumerator.Current, item);
                enumerator.MoveNext();
            }
        } 
        [TestCase(new[] { 1 }, new int[0], 1)]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 2, 3, 4 }, 1)]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 1, 3, 4 }, 2)]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 4 }, 3)]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3 }, 4)]
        public void RemoveFirst(int[] data, int[] goodData, int toRemove)
        {
            var linkedList = new CircularLinkedList<int>(data);
            var enumerator = goodData.GetEnumerator();
            enumerator.MoveNext();
            linkedList.Remove(toRemove);
            Assert.AreEqual(goodData.Length, linkedList.Count);
            foreach (var item in linkedList)
            {
                Assert.AreEqual(enumerator.Current, item);
                enumerator.MoveNext();
            }
        }
    }
}
