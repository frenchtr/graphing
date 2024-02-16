using System;
using System.Collections.Generic;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    /// <summary>
    /// Defines the structure for a graph data structure, supporting generic node and edge types.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of the values stored in the graph's nodes.</typeparam>
    /// <typeparam name="TEdgeValue">The type of the values associated with the graph's edges.</typeparam>
    public interface IGraph<TNodeValue, TEdgeValue>
    {
        /// <summary>
        /// Gets the unique identifier for the graph.
        /// </summary>
        Guid ID { get; }

        /// <summary>
        /// Gets an enumerable collection of the graph's nodes.
        /// </summary>
        IEnumerable<INode<TNodeValue, TEdgeValue>> Nodes { get; }

        /// <summary>
        /// Gets an enumerable collection of the graph's edges.
        /// </summary>
        IEnumerable<IEdge<TNodeValue, TEdgeValue>> Edges { get; }

        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node">The node to be added.</param>
        void AddNode(INode<TNodeValue, TEdgeValue> node);

        /// <summary>
        /// Removes a node from the graph, along with any edges connected to it.
        /// </summary>
        /// <param name="node">The node to be removed.</param>
        void RemoveNode(INode<TNodeValue, TEdgeValue> node);

        /// <summary>
        /// Adds an edge to the graph, connecting two nodes.
        /// </summary>
        /// <param name="edge">The edge to be added.</param>
        void AddEdge(IEdge<TNodeValue, TEdgeValue> edge);

        /// <summary>
        /// Removes an edge from the graph.
        /// </summary>
        /// <param name="edge">The edge to be removed.</param>
        void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge);
    }
}