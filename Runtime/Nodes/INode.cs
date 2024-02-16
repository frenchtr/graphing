using System;
using System.Collections.Generic;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;

namespace TravisRFrench.Graphing.Runtime.Nodes
{
    public interface INode<TNodeValue, TEdgeValue>
    {
        Guid ID { get; }
        IGraph<TNodeValue, TEdgeValue> Graph { get; }
        TNodeValue Value { get; set; }
        IEnumerable<IEdge<TNodeValue, TEdgeValue>> Edges { get; }
        
        void AddEdge(IEdge<TNodeValue, TEdgeValue> edge);
        void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge);
        IEnumerable<INode<TNodeValue, TEdgeValue>> GetNeighbors();
    }
}
