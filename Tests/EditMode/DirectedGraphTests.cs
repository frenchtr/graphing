using System.Linq;
using NUnit.Framework;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Tests.EditMode
{
    /// <summary>
    /// Contains unit tests for the <see cref="DirectedGraph{TNodeValue, TEdgeValue}"/> class.
    /// </summary>
    public class DirectedGraphTests : GraphTests
    {
        /// <summary>
        /// Verifies that adding an edge to a directed graph reflects the correct directionality.
        /// </summary>
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
        
        /// <summary>
        /// Creates an instance of the directed graph for testing purposes.
        /// </summary>
        /// <typeparam name="TNodeValue">The type of value stored in the graph's nodes.</typeparam>
        /// <typeparam name="TEdgeValue">The type of value associated with edges in the graph.</typeparam>
        /// <returns>An instance of the directed graph.</returns>
        protected override IGraph<TNodeValue, TEdgeValue> CreateGraph<TNodeValue, TEdgeValue>()
        {
            return new DirectedGraph<TNodeValue, TEdgeValue>();
        }
    }
}
