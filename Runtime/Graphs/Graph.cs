using System;
using System.Collections.Generic;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    /// <summary>
    /// Represents the base class for a graph data structure, supporting generic node and edge types.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of the values stored in the nodes.</typeparam>
    /// <typeparam name="TEdgeValue">The type of the values associated with the edges.</typeparam>
    public abstract class Graph<TNodeValue, TEdgeValue> : IGraph<TNodeValue, TEdgeValue>
    {
        protected readonly List<INode<TNodeValue, TEdgeValue>> nodes;
        protected readonly List<IEdge<TNodeValue, TEdgeValue>> edges;
        
        /// <summary>
        /// Gets the unique identifier for the graph.
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Gets an enumerable collection of nodes in the graph.
        /// </summary>
        public IEnumerable<INode<TNodeValue, TEdgeValue>> Nodes => nodes.AsReadOnly();

        /// <summary>
        /// Gets an enumerable collection of edges in the graph.
        /// </summary>
        public IEnumerable<IEdge<TNodeValue, TEdgeValue>> Edges => edges.AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the Graph class with a specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the graph.</param>
        protected Graph(Guid id)
        {
            ID = id;
            nodes = new List<INode<TNodeValue, TEdgeValue>>();
            edges = new List<IEdge<TNodeValue, TEdgeValue>>();
        }

        /// <summary>
        /// Initializes a new instance of the Graph class with a generated unique identifier.
        /// </summary>
        protected Graph() : this(Guid.NewGuid()) {}

        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public abstract void AddNode(INode<TNodeValue, TEdgeValue> node);

        /// <summary>
        /// Removes a node from the graph.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        public abstract void RemoveNode(INode<TNodeValue, TEdgeValue> node);

        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <param name="edge">The edge to add.</param>
        public abstract void AddEdge(IEdge<TNodeValue, TEdgeValue> edge);

        /// <summary>
        /// Removes an edge from the graph.
        /// </summary>
        /// <param name="edge">The edge to remove.</param>
        public abstract void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge);
    }
}
