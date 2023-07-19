using System;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Edges
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
