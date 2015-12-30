using System;
using System.Collections.Generic;
using DataStructures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Graphs
{
    [TestClass]
    public class SimplestListGraphTest
    {
        private int N
        {
            get
            {
                Assert.IsTrue(_n > 10);
                return _n;
            } 
        }

        private int _n = 50;
        [TestMethod]
        public void Adding()
        {
            SimplestListGraph<string> graph = new SimplestListGraph<string>();
            AdjencyListVertex<string> v = new AdjencyListVertex<string>("A");
            AdjencyListVertex<string> v2 = new AdjencyListVertex<string>("B");
            AdjencyListVertex<string> v3 = new AdjencyListVertex<string>("C");
            graph.Add(v);
            graph.Add(v2);
            graph.Add(v3);
            Assert.AreEqual(3, graph.VerticesCount);
            graph.Connect(v, v2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConnectNotIncluded()
        {
            var graph = new SimplestListGraph<string>();
            var v1 = new AdjencyListVertex<string>("A");
            var v2 = new AdjencyListVertex<string>("B");
            graph.Add(v1);
            graph.Connect(v1, v2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConnectTwoTimes()
        {
            var graph = new SimplestListGraph<string>();
            var v1 = new AdjencyListVertex<string>("A");
            var v2 = new AdjencyListVertex<string>("B");
            graph.Add(v1);
            graph.Add(v2);
            Assert.AreEqual(2, graph.VerticesCount);
            graph.Connect(v1, v2);
            graph.Connect(v2, v1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConnectingItself()
        {
            SimplestListGraph<string> graph = new SimplestListGraph<string>();
            AdjencyListVertex<string> v1 = new AdjencyListVertex<string>("A");
            AdjencyListVertex<string> v2 = new AdjencyListVertex<string>("B");
            graph.Add(v1);
            graph.Add(v2);
            Assert.AreEqual(2, graph.VerticesCount);
            graph.Connect(v1, v1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExisting()
        {
            var graph = new SimplestListGraph<string>();
            var v1 = new AdjencyListVertex<string>("A");
            graph.Add(v1);
            graph.Add(v1);
        }
        [TestMethod]
        public void VertexCounting()
        {
            var graph = new SimplestListGraph<int>();
            for (int i = 0; i < N; ++i)
                graph.Add(new AdjencyListVertex<int>(i));
            Assert.AreEqual(N, graph.VerticesCount);
        }
        [TestMethod]
        public void EdgeCounting()
        {
            var graph = new SimplestListGraph<int>();
            for (int i = 0; i < N; ++i)
                graph.Add(new AdjencyListVertex<int>(i));
            for (int i = 0; i < N - 1; ++i)
                graph.Connect(i, i + 1);
            Assert.AreEqual(N - 1, graph.EdgesCount);
        }
        [TestMethod]
        public void RemoveVertexCount()
        {
            var graph = new SimplestListGraph<int>();
            for (int i = 0; i < N; ++i)
                graph.Add(new AdjencyListVertex<int>(i));
            Assert.IsTrue(graph.Remove(3));
            Assert.IsFalse(graph.Remove(N + 100));
            Assert.IsTrue(graph.Remove(7));
            Assert.IsTrue(graph.Remove(2));
            Assert.AreEqual(N - 3, graph.VerticesCount);
            Assert.AreEqual(0, graph.EdgesCount);
        }
        [TestMethod]
        public void RemoveEdgeCount()
        {
            var graph = new SimplestListGraph<int>();
            for (int i = 0; i < N; ++i)
                graph.Add(new AdjencyListVertex<int>(i));
            for (int i = 0; i < N - 1; ++i)
                graph.Connect(i, i + 1);
            Assert.AreEqual(N - 1, graph.EdgesCount);
            Assert.IsTrue(graph.RemoveEdge(0, 1));
            Assert.IsTrue(graph.RemoveEdge(1, 2));
            Assert.AreEqual(N - 3, graph.EdgesCount);
        }

        [TestMethod]
        public void GraphTraversalBfs()
        {
            var graph = new SimplestListGraph<int>(0);
            for (int i = 1; i < 5; ++i)
            {
                graph.Add(i);
            }
            Assert.AreEqual(5, graph.VerticesCount);
            Assert.IsTrue(graph.HasRoot());
            Assert.AreEqual(0, graph.Root.Value);
            graph.Connect(0, 1);
            graph.Connect(0, 2);
            graph.Connect(0, 3);
            graph.Connect(0, 4);
            graph.Connect(1, 2);
            graph.Connect(1, 3);
            graph.Connect(1, 4);
            graph.Connect(2, 3);
            graph.Connect(2, 4);
            graph.Connect(3, 4);
            Assert.AreEqual(10, graph.EdgesCount);
            var data = graph.GetBfs();
            Assert.AreEqual(5, data.Count);
            for (int i = 0; i < 5; ++i)
            {
                Assert.AreEqual(i, data[i].Value);
            }
        }

        [TestMethod]
        public void GraphTraversalBfs2()
        {
            var graph = new SimplestListGraph<int>(0);
            for (int i = 1; i < 5; ++i)
            {
                graph.Add(i);
            }
            Assert.AreEqual(5, graph.VerticesCount);
            Assert.IsTrue(graph.HasRoot());
            Assert.AreEqual(0, graph.Root.Value);
            graph.Connect(0, 3);
            graph.Connect(0, 4);
            graph.Connect(1, 2);
            graph.Connect(1, 4);
            graph.Connect(2, 3);
            graph.Connect(3, 4);
            Assert.AreEqual(6, graph.EdgesCount);
            var good = new List<int>
            {
                0,
                3,
                4,
                2,
                1
            };
            var data = graph.GetBfs();
            for (int i = 0; i < 5; ++i)
            {
                Assert.AreEqual(good[i], data[i].Value);
            }
        }

        [TestMethod]
        public void GraphTraversalDfs()
        {
            var graph = new SimplestListGraph<int>(0);
            for (int i = 1; i < 5; ++i)
            {
                graph.Add(i);
            }
            Assert.AreEqual(5, graph.VerticesCount);
            Assert.IsTrue(graph.HasRoot());
            Assert.AreEqual(0, graph.Root.Value);
            graph.Connect(0, 3);
            graph.Connect(0, 4);
            graph.Connect(1, 2);
            graph.Connect(1, 4);
            graph.Connect(2, 3);
            graph.Connect(3, 4);
            Assert.AreEqual(6, graph.EdgesCount);
            var good = new List<int>
            {
               0,4,3,2,1
            };
            var data = graph.GetDfs();
            for (int i = 0; i < 5; ++i)
            {
                Assert.AreEqual(good[i], data[i].Value);
            }
        }

        [TestMethod]
        public void GraphTraversalDfs2()
        {
            var graph = new SimplestListGraph<int>(5);
            int i = 0;
            while (i < 5)
            {
                graph.Add(i);
                ++i;
            }
            ++i;
            while (i < 8)
            {
                graph.Add(i);
                ++i;
            }
            Assert.AreEqual(8, graph.VerticesCount);
            Assert.IsTrue(graph.HasRoot());
            Assert.AreEqual(5, graph.Root.Value);
            graph.Connect(0, 1);
            graph.Connect(0, 2);
            graph.Connect(1, 2);
            graph.Connect(1, 3);
            graph.Connect(2, 4);
            graph.Connect(3, 4);
            graph.Connect(3, 6);
            graph.Connect(4, 5);
            graph.Connect(4, 7);
            graph.Connect(5, 6);
            graph.Connect(6, 7);
            Assert.AreEqual(11, graph.EdgesCount);
            List<int> good = new List<int>
            {
                5,6,7,4,3,1,2,0
            };
            var data = graph.GetDfs();
            for (int k = 0; k < 5; ++k)
            {
                Assert.AreEqual(good[k], data[k].Value);
            }
        }

        [TestMethod]
        public void TreeTraversal()
        {
            var graph = new SimplestListGraph<int>();
            for (int i = 0; i < 11; ++i)
                graph.Add(i);
            graph.SetRoot(7);
            graph.Connect(7, 3);
            graph.Connect(7, 8);
            graph.Connect(3, 1);
            graph.Connect(3, 5);
            graph.Connect(1, 0);
            graph.Connect(1, 2);
            graph.Connect(5, 4);
            graph.Connect(5, 6);
            graph.Connect(8, 9);
            graph.Connect(8, 10);
            Assert.AreEqual(11, graph.VerticesCount);
            Assert.AreEqual(10, graph.EdgesCount);
            var goodBfs = new List<int>
            {
               7,3,8,1,5,9,10,0,2,4,6
            };
            var bfs = graph.GetBfs();
            for (int i = 0; i < 11; ++i)
            {
                Assert.AreEqual(goodBfs[i], bfs[i].Value);
            }
            var goodDfs = new List<int>
            {
               7,8,10,9,3,5,6,4,1,2,0
            };
            var dfs = graph.GetDfs();
            for (int i = 0; i < 11; ++i)
            {
                Assert.AreEqual(goodDfs[i], dfs[i].Value);
            }

        }
    }
}
