﻿using System.Linq;
using NUnit.Framework;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Tests.EditMode
{
    /// <summary>
    /// Contains unit tests for the functionalities specific to undirected graphs.
    /// </summary>
    public class UndirectedGraphTests : GraphTests
    {
        /// <summary>
        /// Verifies that when adding an edge to an undirected graph, the edge should be bidirectional.
        /// </summary>
        [Test]
        public void GivenUndirectedGraph_WhenAddingEdge_ThenEdgeShouldBeBidirectional()
        {
            // Given
            var graph = this.CreateGraph<string, int>();
            var node1 = new Node<string, int>(graph, "Node1");
            var node2 = new Node<string, int>(graph, "Node2");
            graph.AddNode(node1);
            graph.AddNode(node2);

            // When
            var edge = new Edge<string, int>(graph, node1, node2, 1); // Assuming Edge's weight/value is of type int
            graph.AddEdge(edge);

            // Then
            // Verify that the edge can be traversed in both directions
            Assert.IsTrue(graph.Edges.Any(e => e.First == node1 && e.Second == node2), "The edge should exist from node1 to node2.");
            Assert.IsTrue(graph.Edges.Any(e => e.First == node2 && e.Second == node1), "The edge should also exist from node2 to node1, reflecting bidirectionality.");
        }
        
        /// <summary>
        /// Creates an instance of an undirected graph for testing purposes.
        /// </summary>
        /// <typeparam name="TNodeValue">The type of value stored in the graph's nodes.</typeparam>
        /// <typeparam name="TEdgeValue">The type of value associated with edges in the graph.</typeparam>
        /// <returns>An instance of an undirected graph.</returns>
        protected override IGraph<TNodeValue, TEdgeValue> CreateGraph<TNodeValue, TEdgeValue>()
        {
            return new UndirectedGraph<TNodeValue, TEdgeValue>();
        }
    }
}
