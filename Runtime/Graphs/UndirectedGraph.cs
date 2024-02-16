using System;
using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    /// <summary>
    /// Represents an undirected graph where each edge connects two nodes bidirectionally.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of the values stored in the nodes.</typeparam>
    /// <typeparam name="TEdgeValue">The type of the values associated with the edges.</typeparam>
    public class UndirectedGraph<TNodeValue, TEdgeValue> : Graph<TNodeValue, TEdgeValue>
    {
        /// <summary>
        /// Initializes a new instance of the UndirectedGraph class with a specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the graph.</param>
        public UndirectedGraph(Guid id)
            : base(id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the UndirectedGraph class with a generated unique identifier.
        /// </summary>
        public UndirectedGraph()
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
        /// Adds an edge to the graph. For undirected graphs, an inverse edge is also added to ensure bidirectionality.
        /// </summary>
        /// <param name="edge">The edge to add. An inverse edge with the same value will also be added.</param>
        public override void AddEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            var inverseEdge = new Edge<TNodeValue, TEdgeValue>(
                Guid.NewGuid(), 
                this, 
                edge.Second, 
                edge.First, 
                edge.Value);

            this.edges.Add(edge);
            this.edges.Add(inverseEdge);
        }

        /// <summary>
        /// Removes an edge from the graph. The inverse edge, if exists, is also removed.
        /// </summary>
        /// <param name="edge">The edge to remove from the graph.</param>
        public override void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            // In removing an edge in an undirected graph, also attempt to remove the "inverse" edge.
            var inverseEdge = this.edges.FirstOrDefault(e => e.First == edge.Second && e.Second == edge.First && Equals(e.Value, edge.Value));
            if (edge != null) this.edges.Remove(edge);
            if (inverseEdge != null) this.edges.Remove(inverseEdge);
        }
    }
}
