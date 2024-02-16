using System;
using System.Collections.Generic;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;

namespace TravisRFrench.Graphing.Runtime.Nodes
{
    /// <summary>
    /// Defines the structure and functionality of a node within a graph, supporting generic types for node values and edge values.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of the value stored in the node.</typeparam>
    /// <typeparam name="TEdgeValue">The type of the values associated with the edges connected to this node.</typeparam>
    public interface INode<TNodeValue, TEdgeValue>
    {
        /// <summary>
        /// Gets the unique identifier of the node.
        /// </summary>
        Guid ID { get; }

        /// <summary>
        /// Gets the graph to which this node belongs.
        /// </summary>
        IGraph<TNodeValue, TEdgeValue> Graph { get; }

        /// <summary>
        /// Gets or sets the value stored in the node.
        /// </summary>
        TNodeValue Value { get; set; }

        /// <summary>
        /// Gets an enumerable collection of edges connected to this node.
        /// </summary>
        IEnumerable<IEdge<TNodeValue, TEdgeValue>> Edges { get; }
        
        /// <summary>
        /// Adds an edge connected to this node.
        /// </summary>
        /// <param name="edge">The edge to be added.</param>
        void AddEdge(IEdge<TNodeValue, TEdgeValue> edge);

        /// <summary>
        /// Removes an edge connected to this node.
        /// </summary>
        /// <param name="edge">The edge to be removed.</param>
        void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge);

        /// <summary>
        /// Gets an enumerable collection of neighboring nodes connected to this node by edges.
        /// </summary>
        /// <returns>An enumerable collection of nodes that are neighbors of this node.</returns>
        IEnumerable<INode<TNodeValue, TEdgeValue>> GetNeighbors();
    }
}
