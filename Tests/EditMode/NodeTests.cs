using NUnit.Framework;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Nodes;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;

namespace TravisRFrench.Graphing.Tests.EditMode
{
    [TestFixture]
    public class NodeTests
    {
        private IGraph<string, int> graph;
        private Node<string, int> node1;
        private Node<string, int> node2;
        
        [SetUp]
        public void SetUp()
        {
            // Setup your graph, nodes, and edges before each test
            this.graph = new UndirectedGraph<string, int>();
            this.node1 = new Node<string, int>(this.graph, "Node1");
            this.node2 = new Node<string, int>(this.graph, "Node2");

            this.graph.AddNode(this.node1);
            this.graph.AddNode(this.node2);
        }

        [Test]
        public void AddEdge_ShouldLinkTwoNodes()
        {
            // Given an edge is added between node1 and node2
            var edge = new Edge<string, int>(this.graph, this.node1, this.node2, 1);
            this.node1.AddEdge(edge);

            // Then node1's edges should contain the added edge
            Assert.Contains(edge, this.node1.Edges.ToList());

            // And node2 should be a neighbor of node1
            Assert.Contains(this.node2, this.node1.GetNeighbors().ToList());
        }

        [Test]
        public void RemoveEdge_ShouldUnlinkTwoNodes()
        {
            // Given an edge is added then removed between node1 and node2
            var edge = new Edge<string, int>(this.graph, this.node1, this.node2, 1);
            this.node1.AddEdge(edge);
            this.node1.RemoveEdge(edge);

            // Then node1's edges should not contain the removed edge
            Assert.IsFalse(this.node1.Edges.Contains(edge));

            // And node2 should not be a neighbor of node1
            Assert.IsFalse(this.node1.GetNeighbors().Contains(this.node2));
        }
    }
}
