using System;
using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Edges;
using TravisRFrench.Graphing.Graphs;

namespace TravisRFrench.Graphing.Nodes
{
    [Serializable]
    public class Node<TValue> : INode<TValue>
    {
        public Guid ID { get; }
        public IGraph<TValue> Graph { get; }
        public TValue Value { get; set; }
        public IEnumerable<IEdge<TValue>> Edges => this.Graph.Edges.Where(edge => edge.First == this);

        public Node(Guid id, IGraph<TValue> graph, TValue value = default)
        {
            this.ID = id;
            this.Graph = graph;
            this.Value = value;
        }

        public Node(IGraph<TValue> graph, TValue value = default)
            : this(Guid.NewGuid(), graph, value)
        {
        }
        
        public void AddNeighbor(INode<TValue> neighbor, float weight = default)
        {
            this.Graph.AddEdge(this, neighbor, weight);
        }

        public void RemoveNeighbor(INode<TValue> neighbor)
        {
            this.Graph.RemoveEdge(this, neighbor);
        }

        public void AddEdge(IEdge<TValue> edge)
        {
            this.Graph.AddEdge(edge);
        }

        public void RemoveEdge(IEdge<TValue> edge)
        {
            this.Graph.RemoveEdge(edge);
        }

        public IEnumerable<INode<TValue>> GetNeighbors()
        {
            var edges = this.Edges.Where(e => e.First == this || e.Second == this);
            var neighbors = new List<INode<TValue>>();

            foreach (var edge in edges)
            {
                var neighbor = edge.First == this ? edge.Second : edge.First;

                if (neighbors.Any(n => n == neighbor))
                {
                    continue;
                }
                
                neighbors.Add(neighbor);
            }

            return neighbors;
        }
    }
}
