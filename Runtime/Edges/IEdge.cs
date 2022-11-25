using System;
using TravisRFrench.Graphing.Graphs;
using TravisRFrench.Graphing.Nodes;

namespace TravisRFrench.Graphing.Edges
{
    public interface IEdge<TValue> 
    {
        Guid ID { get; }
        IGraph<TValue> Graph { get; }
        INode<TValue> First { get; }
        INode<TValue> Second { get; }
        float Weight { get; set; }
    }
}
