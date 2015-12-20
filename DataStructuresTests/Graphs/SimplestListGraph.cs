using DataStructures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Graphs
{
    [TestClass]
    public class SimplestListGraph
    {
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
            graph.Connect(v, v2);
            graph.Connect(v, v2); 


        }
    }
}
