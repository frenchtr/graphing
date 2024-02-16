using System.Collections.Generic;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Search
{
    /// <summary>
    /// Represents an interface for graph search algorithms.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of value stored in the graph's nodes.</typeparam>
    /// <typeparam name="TEdgeValue">The type of value associated with edges in the graph.</typeparam>
    public interface IGraphSearcher<TNodeValue, TEdgeValue>
    {
        /// <summary>
        /// Searches for nodes within a graph based on a specified starting node using a specific search algorithm.
        /// </summary>
        /// <param name="graph">The graph in which the search operation will be performed.</param>
        /// <param name="startNode">The node from which the search will begin.</param>
        /// <returns>An enumerable collection of nodes resulting from the search operation.</returns>
        IEnumerable<INode<TNodeValue, TEdgeValue>> Search(IGraph<TNodeValue, TEdgeValue> graph, INode<TNodeValue, TEdgeValue> startNode);
    }
}
