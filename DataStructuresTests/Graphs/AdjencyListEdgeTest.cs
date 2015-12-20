using System;
using DataStructures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Graphs
{
    [TestClass]
    public class AdjencyListEdgeTest
    {
        [TestMethod]
        public void AddingToEdge()
        {
            var v1 = new AdjencyListVertex<string>("abc"); 
            var v2 = new AdjencyListVertex<string>("def");
            var e = new Edge<string>(v1, v2);
            Assert.AreEqual("abc",e.First.Value);
            Assert.AreEqual("def", e.Second.Value);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Already connected")]
        public void ConnectAgain()
        {
            var v1 = new AdjencyListVertex<string>("abc");
            var v2 = new AdjencyListVertex<string>("def");
            Edge<string> e = new Edge<string>(v1, v2);
            Edge<string> e2 = new Edge<string>(v1, v2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Already connected")]
        public void ConnectAgain2()
        {
            var v1 = new AdjencyListVertex<string>("abc");
            var v2 = new AdjencyListVertex<string>("def");
            v1.Connect(v2);
            v2.Connect(v1);
            Edge<string> e = new Edge<string>(v1, v2); 
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot add himself")]
        public void ConnectTheSame()
        {
            var v1 = new AdjencyListVertex<string>("abc");  
            Edge<string> e = new Edge<string>(v1, v1);
        }
    }
}
