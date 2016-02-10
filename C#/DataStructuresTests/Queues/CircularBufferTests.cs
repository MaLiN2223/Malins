using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Queues
{
    using DataStructures.Queues;

    [TestClass]
    public class CircularBufferTests
    {
        [TestMethod]
        public void InitEmpty()
        {
            CircularBuffer<int> buffer = new CircularBuffer<int>();
            Assert.IsTrue(buffer.Empty);
            Assert.AreEqual(0, buffer.MaxSize);
        }

        [TestMethod]
        public void InitNonEmpty()
        {
            CircularBuffer<int> buffer = new CircularBuffer<int>(10);
            Assert.IsTrue(buffer.Empty);
            Assert.AreEqual(10, buffer.MaxSize);
        }

        [TestMethod]
        public void PushBack()
        {
            CircularBuffer<int> buffer = new CircularBuffer<int>(10);
        }
    }
}
