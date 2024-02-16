using System;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Edges
{
    public interface IEdge<TNodeValue, TEdgeValue>
    {
        Guid ID { get; }
        IGraph<TNodeValue, TEdgeValue> Graph { get; }
        INode<TNodeValue, TEdgeValue> First { get; }
        INode<TNodeValue, TEdgeValue> Second { get; }
        TEdgeValue Value { get; set; }
    }
}
