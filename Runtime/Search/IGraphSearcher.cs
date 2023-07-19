using System.Collections.Generic;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Search
{
    public interface IGraphSearcher
    {
        IEnumerable<INode<TValue>> Search<TValue>(IGraph<TValue> graph, INode<TValue> startNode);
    }
}
