using System;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Edges
{
    /// <summary>
    /// Represents an edge in a graph, connecting two nodes.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of the values stored in the nodes.</typeparam>
    /// <typeparam name="TEdgeValue">The type of the value stored in the edge.</typeparam>
    public interface IEdge<TNodeValue, TEdgeValue>
    {
        /// <summary>
        /// Gets the unique identifier for the edge.
        /// </summary>
        Guid ID { get; }

        /// <summary>
        /// Gets the graph to which the edge belongs.
        /// </summary>
        IGraph<TNodeValue, TEdgeValue> Graph { get; }

        /// <summary>
        /// Gets the first node connected by the edge.
        /// </summary>
        INode<TNodeValue, TEdgeValue> First { get; }

        /// <summary>
        /// Gets the second node connected by the edge.
        /// </summary>
        INode<TNodeValue, TEdgeValue> Second { get; }

        /// <summary>
        /// Gets or sets the value associated with the edge.
        /// </summary>
        TEdgeValue Value { get; set; }
    }
}
