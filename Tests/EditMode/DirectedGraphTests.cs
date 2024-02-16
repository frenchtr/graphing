using System.Linq;
using NUnit.Framework;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Tests.EditMode
{
    public class DirectedGraphTests : GraphTests
    {
        [Test]
        public void GivenDirectedGraph_WhenAddingEdge_ThenEdgeShouldReflectDirectionality()
        {
            // Given
            var graph = this.CreateGraph<string, int>();
            var node1 = new Node<string, int>(graph, "Source");
            var node2 = new Node<string, int>(graph, "Destination");
            graph.AddNode(node1);
            graph.AddNode(node2);

            // When
            var edge = new Edge<string, int>(graph, node1, node2, 10); // Direction: node1 -> node2
            graph.AddEdge(edge);

            // Then
            Assert.IsTrue(graph.Edges.Any(e => e.First == node1 && e.Second == node2), "The edge should reflect the correct directionality from node1 to node2.");
        }
        
        protected override IGraph<TNodeValue, TEdgeValue> CreateGraph<TNodeValue, TEdgeValue>()
        {
            return new DirectedGraph<TNodeValue, TEdgeValue>();
        }
    }
}
