using System;
using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;

namespace TravisRFrench.Graphing.Runtime.Nodes
{
    /// <summary>
    /// Represents a node within a graph, supporting generic types for both the node's value and the values of connected edges.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of the value stored in the node.</typeparam>
    /// <typeparam name="TEdgeValue">The type of the values associated with edges connected to this node.</typeparam>
    [Serializable]
    public class Node<TNodeValue, TEdgeValue> : INode<TNodeValue, TEdgeValue>
    {
        /// <summary>
        /// Gets the unique identifier for the node.
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Gets the graph to which this node belongs, allowing for interaction with the broader graph structure.
        /// </summary>
        public IGraph<TNodeValue, TEdgeValue> Graph { get; }

        /// <summary>
        /// Gets or sets the value associated with this node.
        /// </summary>
        public TNodeValue Value { get; set; }

        /// <summary>
        /// Gets an enumerable collection of edges connected to this node, allowing for traversal and manipulation of connected nodes.
        /// </summary>
        public IEnumerable<IEdge<TNodeValue, TEdgeValue>> Edges => this.Graph.Edges.Where(edge => edge.First == this || edge.Second == this);

        /// <summary>
        /// Initializes a new instance of the Node class with a specified identifier, graph, and optional value.
        /// </summary>
        /// <param name="id">The unique identifier of the node.</param>
        /// <param name="graph">The graph to which this node belongs.</param>
        /// <param name="value">The initial value of the node. Defaults to the default value of TNodeValue if not provided.</param>
        public Node(Guid id, IGraph<TNodeValue, TEdgeValue> graph, TNodeValue value = default)
        {
            this.ID = id;
            this.Graph = graph;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the Node class with a generated unique identifier, associated graph, and optional value.
        /// </summary>
        /// <param name="graph">The graph to which this node belongs.</param>
        /// <param name="value">The initial value of the node. Defaults to the default value of TNodeValue if not provided.</param>
        public Node(IGraph<TNodeValue, TEdgeValue> graph, TNodeValue value = default)
            : this(Guid.NewGuid(), graph, value)
        {
        }

        /// <summary>
        /// Adds an edge connected to this node to the graph.
        /// </summary>
        /// <param name="edge">The edge to be added.</param>
        public void AddEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            this.Graph.AddEdge(edge);
        }

        /// <summary>
        /// Removes an edge connected to this node from the graph.
        /// </summary>
        /// <param name="edge">The edge to be removed.</param>
        public void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            this.Graph.RemoveEdge(edge);
        }

        /// <summary>
        /// Returns an enumerable collection of nodes that are directly connected to this node via edges, representing the node's neighbors.
        /// </summary>
        /// <returns>An enumerable collection of neighboring nodes.</returns>
        public IEnumerable<INode<TNodeValue, TEdgeValue>> GetNeighbors()
        {
            var neighbors = new List<INode<TNodeValue, TEdgeValue>>();

            foreach (var edge in this.Edges)
            {
                INode<TNodeValue, TEdgeValue> neighbor = edge.First.Equals(this) ? edge.Second : edge.First;
                if (!neighbors.Contains(neighbor))
                {
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }
    }
}
