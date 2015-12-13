using System; 
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Graphs;
namespace DataStructuresTests.Graphs
{
    [TestClass]
    public class AdjencyListVertexTest
    {
        [TestMethod]
        public void EmptyVertex()
        {
            var vertex = new AdjencyListVertex<double>(1.3);
            var vertex2 = new AdjencyListVertex<double>(1);
            Assert.AreEqual(1.3, vertex.Value);
            Assert.AreEqual(0, vertex.Count());
            Assert.AreEqual(0,vertex.Neighbors().Count());
            Assert.IsNull(vertex.GetEnumerator().Current);
            Assert.IsFalse(vertex.IsAdjacent(vertex2));
            foreach (var v in vertex) 
                Assert.Fail(); 
        }
        [TestMethod]
        public void CreatingAndConnecting()
        {
            var vertex = new AdjencyListVertex<string>[]
            {
                new AdjencyListVertex<string>("A"),
                new AdjencyListVertex<string>("B"),
                new AdjencyListVertex<string>("C"),
                new AdjencyListVertex<string>("D"),
                new AdjencyListVertex<string>("E"),
                new AdjencyListVertex<string>("F"),
                new AdjencyListVertex<string>("G"),
                new AdjencyListVertex<string>("H"),
                new AdjencyListVertex<string>("I"),
            };
            Assert.AreEqual(vertex[0].Value, "A");
            Assert.AreEqual(vertex[1].Value, "B");
            Assert.AreEqual(vertex[2].Value, "C");
            Assert.AreEqual(vertex[3].Value, "D");
            Assert.AreEqual(vertex[4].Value, "E");
            Assert.AreEqual(vertex[5].Value, "F");
            Assert.AreEqual(vertex[6].Value, "G");
            Assert.AreEqual(vertex[7].Value, "H");
            Assert.AreEqual(vertex[8].Value, "I");

        }
        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Can't add null")]
        public void ConnectNull()
        {
            var vertex = new AdjencyListVertex<int>(0);
            vertex.Connect(null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot add himself")]
        public void ConnectHimself()
        {
            var vertex = new AdjencyListVertex<int>(0);
            vertex.Connect(vertex);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Vertices are already connected")]
        public void ConnectAgain()
        {
            var vertex = new AdjencyListVertex<int>(0);
            var vertex2 = new AdjencyListVertex<int>(-1);
            vertex.Connect(vertex2);
            vertex.Connect(vertex2);
        }
        [TestMethod]
        public void ConnectingValidation()
        {
            var vertex = new AdjencyListVertex<string>[]
           {
                new AdjencyListVertex<string>("A"),
                new AdjencyListVertex<string>("B"),
                new AdjencyListVertex<string>("C"),
                new AdjencyListVertex<string>("D"),
                new AdjencyListVertex<string>("E"),
                new AdjencyListVertex<string>("F"),
                new AdjencyListVertex<string>("G"),
                new AdjencyListVertex<string>("H"),
                new AdjencyListVertex<string>("I"),
                new AdjencyListVertex<string>("J"),
           };
            vertex[0].Connect(vertex[1]); 
            vertex[1].Connect(vertex[2]);
            vertex[1].Connect(vertex[4]); 
            vertex[2].Connect(vertex[3]); 
            vertex[3].Connect(vertex[4]);
            vertex[3].Connect(vertex[5]); 
            vertex[5].Connect(vertex[6]);
            vertex[5].Connect(vertex[7]);
            vertex[5].Connect(vertex[8]);
            vertex[7].Connect(vertex[8]); 

            Assert.AreEqual(1,vertex[0].Neighbors().Count());
            Assert.AreEqual(3,vertex[1].Neighbors().Count());
            Assert.AreEqual(2,vertex[2].Neighbors().Count());
            Assert.AreEqual(3,vertex[3].Neighbors().Count());
            Assert.AreEqual(2,vertex[4].Neighbors().Count());
            Assert.AreEqual(4,vertex[5].Neighbors().Count());
            Assert.AreEqual(1,vertex[6].Neighbors().Count());
            Assert.AreEqual(2,vertex[7].Neighbors().Count());
            Assert.AreEqual(2,vertex[8].Neighbors().Count());
            Assert.AreEqual(0,vertex[9].Neighbors().Count()); 
        }
 
    }
}
