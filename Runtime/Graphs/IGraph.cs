using System;
using System.Collections.Generic;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    public interface IGraph<TNodeValue, TEdgeValue>
    {
        Guid ID { get; }
        IEnumerable<INode<TNodeValue, TEdgeValue>> Nodes { get; }
        IEnumerable<IEdge<TNodeValue, TEdgeValue>> Edges { get; }

        void AddNode(INode<TNodeValue, TEdgeValue> node);
        void RemoveNode(INode<TNodeValue, TEdgeValue> node);
        void AddEdge(IEdge<TNodeValue, TEdgeValue> edge);
        void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge);
    }
}
