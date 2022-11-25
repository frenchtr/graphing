using System;
using System.Collections.Generic;
using TravisRFrench.Graphing.Edges;
using TravisRFrench.Graphing.Nodes;

namespace TravisRFrench.Graphing.Graphs
{
    public interface IGraph<TValue>
    {
        Guid ID { get; }
        IEnumerable<INode<TValue>> Nodes { get; }
        IEnumerable<IEdge<TValue>> Edges { get; }

        void AddNode(INode<TValue> node);
        void RemoveNode(INode<TValue> node);
        void AddEdge(IEdge<TValue> edge);
        void RemoveEdge(IEdge<TValue> edge);
    }
}
