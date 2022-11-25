using System;
using TravisRFrench.Graphing.Graphs;
using TravisRFrench.Graphing.Nodes;

namespace TravisRFrench.Graphing.Edges
{
    [Serializable]
    public class Edge<TValue> : IEdge<TValue>
    {
        public Guid ID { get; }
        public IGraph<TValue> Graph { get; }
        public INode<TValue> First { get; }
        public INode<TValue> Second { get; }
        public float Weight { get; set; }

        public Edge(Guid id, IGraph<TValue> graph, INode<TValue> source, INode<TValue> destination, float weight = default)
        {
            if (source.Graph != graph || destination.Graph != graph)
            {
                throw new InvalidOperationException($"Cannot create edge between nodes on differing graphs.");
            }

            this.ID = id;
            this.Graph = graph;
            this.First = source;
            this.Second = destination;
            this.Weight = weight;
        }

        public Edge(IGraph<TValue> graph, INode<TValue> source, INode<TValue> destination, float weight = default)
            : this(Guid.NewGuid(), graph, source, destination, weight)
        {
        }
    }
}
