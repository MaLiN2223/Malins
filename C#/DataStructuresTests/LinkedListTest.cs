using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Lists;
namespace DataStructuresTests
{
    [TestClass]
    public class LinkedListTest
    {
        private class TestObject : IEquatable<TestObject>
        {
            public int A { get; set; }
            public string B { get; set; }
            public bool Equals(TestObject other)
            {
                return (A == other.A && B == other.B);
            }
        }
        private const int Size = 30;

        [TestMethod]
        public void Counting()
        { 
            var list = new LinkedList<TestObject>();
            for (int i = 0; i < Size; ++i)
            {
                list.Add(new TestObject()); 
            }
            Assert.AreEqual(list.Count,Size);
        }

        [TestMethod]
        public void First()
        { 
             
        }
        [TestMethod]
        public void EmptyList()
        {
            var list = new LinkedList<TestObject>();
            Assert.AreEqual(0,list.Count);
            Assert.IsNull(list.Last);
            Assert.IsNull(list.First);
        } 
    }
}
