using System;
using NUnit.Framework;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Nodes;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;

namespace TravisRFrench.Graphing.Tests.EditMode
{
    public abstract class GraphTests
    {
        [Test]
        public void GivenGraph_WhenAddingNode_ThenNodeShouldBePresent()
        {
            // Given
            var graph = this.CreateGraph<string, int>();
            var node = new Node<string, int>(graph, "Node1");

            // When
            graph.AddNode(node);

            // Then
            Assert.Contains(node, graph.Nodes.ToList());
        }

        [Test]
        public void GivenGraphWithNode_WhenRemovingNode_ThenNodeShouldNotBePresent()
        {
            // Given
            var graph = this.CreateGraph<string, int>();
            var node = new Node<string, int>(graph, "Node1");
            graph.AddNode(node);

            // When
            graph.RemoveNode(node);

            // Then
            Assert.IsFalse(graph.Nodes.Contains(node));
        }

        [Test]
        public void GivenGraphWithTwoNodes_WhenAddingEdgeBetweenNodes_ThenEdgeShouldBePresent()
        {
            // Given
            var graph = this.CreateGraph<string, int>();
            var node1 = new Node<string, int>(graph, "Node1");
            var node2 = new Node<string, int>(graph, "Node2");

            // When
            var edge = new Edge<string, int>(graph, node1, node2, 5);
            graph.AddEdge(edge);

            // Then
            Assert.Contains(edge, graph.Edges.ToList());
        }

        [Test]
        public void GivenGraphWithAnEdge_WhenRemovingEdge_ThenEdgeShouldNotBePresent()
        {
            // Given
            var graph = this.CreateGraph<string, int>();
            var node1 = new Node<string, int>(graph, "Node1");
            var node2 = new Node<string, int>(graph, "Node2");
            var edge = new Edge<string, int>(graph, node1, node2, 5);
            graph.AddEdge(edge);

            // When
            graph.RemoveEdge(edge);

            // Then
            Assert.IsFalse(graph.Edges.Contains(edge));
        }
        
        [Test]
        public void GivenGraph_WhenInitialized_ShouldHaveEmptyNodesAndEdges()
        {
            // Given
            var graph = this.CreateGraph<string, int>();
        
            // Then
            Assert.IsNotNull(graph.Nodes, "Nodes collection should be initialized.");
            Assert.IsEmpty(graph.Nodes, "Nodes collection should be empty upon initialization.");
        
            Assert.IsNotNull(graph.Edges, "Edges collection should be initialized.");
            Assert.IsEmpty(graph.Edges, "Edges collection should be empty upon initialization.");
        }
        
        [Test]
        public void GivenGraph_WhenInitialized_ShouldHaveUniqueID()
        {
            // Given
            var graph = this.CreateGraph<string, int>();
        
            // Then
            Assert.AreNotEqual(Guid.Empty, graph.ID, "Graph should have a unique ID upon initialization.");
        }

        protected abstract IGraph<TNodeValue, TEdgeValue> CreateGraph<TNodeValue, TEdgeValue>();
    }
}
