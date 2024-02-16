using System;
using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;

namespace TravisRFrench.Graphing.Runtime.Nodes
{
    [Serializable]
    // Updated to include TEdgeValue, making the Node class dual-generic.
    public class Node<TNodeValue, TEdgeValue> : INode<TNodeValue, TEdgeValue>
    {
        public Guid ID { get; }
        // Graph now also generic over TNodeValue and TEdgeValue.
        public IGraph<TNodeValue, TEdgeValue> Graph { get; }
        public TNodeValue Value { get; set; }
        // Edges now filtered by the updated interface type, reflecting dual-generic parameters.
        public IEnumerable<IEdge<TNodeValue, TEdgeValue>> Edges => this.Graph.Edges.Where(edge => edge.First == this || edge.Second == this);

        public Node(Guid id, IGraph<TNodeValue, TEdgeValue> graph, TNodeValue value = default)
        {
            this.ID = id;
            this.Graph = graph;
            this.Value = value;
        }

        public Node(IGraph<TNodeValue, TEdgeValue> graph, TNodeValue value = default)
            : this(Guid.NewGuid(), graph, value)
        {
        }

        // Adjusted to include TEdgeValue in the AddEdge and RemoveEdge methods.
        public void AddEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            this.Graph.AddEdge(edge);
        }

        public void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            this.Graph.RemoveEdge(edge);
        }

        // Returns neighbors, ensuring the correct edge type is used.
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
