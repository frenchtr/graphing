using System;
using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    /// <summary>
    /// Represents a directed graph where each edge has a direction pointing from one node to another.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of values stored in the graph's nodes.</typeparam>
    /// <typeparam name="TEdgeValue">The type of values stored in the graph's edges.</typeparam>
    public class DirectedGraph<TNodeValue, TEdgeValue> : Graph<TNodeValue, TEdgeValue>
    {
        /// <summary>
        /// Initializes a new instance of the DirectedGraph class with a specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the graph.</param>
        public DirectedGraph(Guid id)
            : base(id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DirectedGraph class with a generated unique identifier.
        /// </summary>
        public DirectedGraph()
        {
        }
        
        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node">The node to be added to the graph.</param>
        public override void AddNode(INode<TNodeValue, TEdgeValue> node)
        {
            this.nodes.Add(node);
        }
        
        /// <summary>
        /// Removes a node from the graph, including all edges connected to it.
        /// </summary>
        /// <param name="node">The node to be removed from the graph.</param>
        public override void RemoveNode(INode<TNodeValue, TEdgeValue> node)
        {
            var edgesToRemove = new List<IEdge<TNodeValue, TEdgeValue>>(this.edges.Where(e => e.First == node || e.Second == node));
            foreach (var edge in edgesToRemove)
            {
                this.edges.Remove(edge);
            }
            
            this.nodes.Remove(node);
        }
        
        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <remarks>
        /// The edge is added only if both nodes associated with the edge are part of this graph.
        /// </remarks>
        /// <param name="edge">The edge to be added to the graph.</param>
        /// <exception cref="InvalidOperationException">Thrown when either of the edge's nodes does not belong to this graph.</exception>
        public override void AddEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            if (edge.First.Graph != this || edge.Second.Graph != this)
            {
                throw new InvalidOperationException($"Cannot add edge to node on a different graph.");
            }
            
            this.edges.Add(edge);
        }
        
        /// <summary>
        /// Removes an edge from the graph.
        /// </summary>
        /// <param name="edge">The edge to be removed from the graph.</param>
        public override void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            this.edges.Remove(edge);
        }
    }
}
