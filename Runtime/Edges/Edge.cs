using System;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Edges
{
    [Serializable]
    public class Edge<TNodeValue, TEdgeValue> : IEdge<TNodeValue, TEdgeValue>
    {
        public Guid ID { get; }
        public IGraph<TNodeValue, TEdgeValue> Graph { get; }
        public INode<TNodeValue, TEdgeValue> First { get; }
        public INode<TNodeValue, TEdgeValue> Second { get; }
        public TEdgeValue Value { get; set; }

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

        public Edge(IGraph<TNodeValue, TEdgeValue> graph, INode<TNodeValue, TEdgeValue> first, INode<TNodeValue, TEdgeValue> second, TEdgeValue value = default)
            : this(Guid.NewGuid(), graph, first, second, value)
        {
        }
    }
}
