using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Search
{
    /// <summary>
    /// Represents a depth-first graph search algorithm.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of value stored in the graph's nodes.</typeparam>
    /// <typeparam name="TEdgeValue">The type of value associated with edges in the graph.</typeparam>
    public class DepthFirstSearcher<TNodeValue, TEdgeValue> : IGraphSearcher<TNodeValue, TEdgeValue>
    {
        /// <summary>
        /// Conducts a depth-first search within the specified graph starting from the given node.
        /// </summary>
        /// <param name="graph">The graph in which the search operation will be performed.</param>
        /// <param name="startNode">The node from which the search will begin.</param>
        /// <returns>An enumerable collection of nodes traversed during the search operation.</returns>
        public IEnumerable<INode<TNodeValue, TEdgeValue>> Search(IGraph<TNodeValue, TEdgeValue> graph, INode<TNodeValue, TEdgeValue> startNode)
        {
            var stack = new Stack<INode<TNodeValue, TEdgeValue>>();
            var visited = new HashSet<INode<TNodeValue, TEdgeValue>>();

            stack.Push(startNode);
            visited.Add(startNode);

            while (stack.Any())
            {
                var current = stack.Pop();

                yield return current;

                var neighbors = current.GetNeighbors().Where(n => !visited.Contains(n)).ToList();
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }
    }
}
