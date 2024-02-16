using System;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Edges
{
    /// <summary>
    /// Represents a connection (or "edge") between two nodes in a graph, with an optional value associated with it.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of the values stored in the nodes connected by this edge.</typeparam>
    /// <typeparam name="TEdgeValue">The type of the value stored in this edge.</typeparam>
    [Serializable]
    public class Edge<TNodeValue, TEdgeValue> : IEdge<TNodeValue, TEdgeValue>
    {
        /// <summary>
        /// Initializes a new instance of the Edge class with specified nodes, graph, and optional value.
        /// </summary>
        /// <param name="id">The unique identifier of the edge.</param>
        /// <param name="graph">The graph to which this edge belongs.</param>
        /// <param name="first">The first node connected by this edge.</param>
        /// <param name="second">The second node connected by this edge.</param>
        /// <param name="value">The value associated with this edge. Defaults to the default value of TEdgeValue if not provided.</param>
        public Edge(Guid id, IGraph<TNodeValue, TEdgeValue> graph, INode<TNodeValue, TEdgeValue> first, INode<TNodeValue, TEdgeValue> second, TEdgeValue value = default)
        {
            if (first.Graph != graph || second.Graph != graph)
            {
                throw new InvalidOperationException($"Cannot create edge between nodes on differing graphs.");
            }

            this.ID = id;
            this.Graph = graph;
            this.First = first;
            this.Second = second;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the Edge class with specified nodes and graph, automatically generating a unique ID.
        /// </summary>
        /// <param name="graph">The graph to which this edge belongs.</param>
        /// <param name="first">The first node connected by this edge.</param>
        /// <param name="second">The second node connected by this edge.</param>
        /// <param name="value">The value associated with this edge. Defaults to the default value of TEdgeValue if not provided.</param>
        public Edge(IGraph<TNodeValue, TEdgeValue> graph, INode<TNodeValue, TEdgeValue> first, INode<TNodeValue, TEdgeValue> second, TEdgeValue value = default)
            : this(Guid.NewGuid(), graph, first, second, value)
        {
        }

        /// <summary>Gets the unique identifier for this edge.</summary>
        public Guid ID { get; }

        /// <summary>Gets the graph to which this edge belongs.</summary>
        public IGraph<TNodeValue, TEdgeValue> Graph { get; }

        /// <summary>Gets the first node connected by this edge.</summary>
        public INode<TNodeValue, TEdgeValue> First { get; }

        /// <summary>Gets the second node connected by this edge.</summary>
        public INode<TNodeValue, TEdgeValue> Second { get; }

        /// <summary>Gets or sets the value associated with this edge.</summary>
        public TEdgeValue Value { get; set; }
    }
}
