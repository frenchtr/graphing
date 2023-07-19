using System;
using System.Collections.Generic;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;

namespace TravisRFrench.Graphing.Runtime.Nodes
{
    public interface INode<TValue>
    {
        Guid ID { get; }
        IGraph<TValue> Graph { get; }
        TValue Value { get; set; }
        IEnumerable<IEdge<TValue>> Edges { get; }
        
        void AddEdge(IEdge<TValue> edge);
        void RemoveEdge(IEdge<TValue> edge);
        IEnumerable<INode<TValue>> GetNeighbors();
        void AddNeighbor(INode<TValue> neighbor, float weight = default);
        void RemoveNeighbor(INode<TValue> neighbor);
    }
}
