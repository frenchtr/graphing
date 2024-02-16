using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Search
{
    /// <summary>
    /// Represents a breadth-first graph search algorithm.
    /// </summary>
    /// <typeparam name="TNodeValue">The type of value stored in the graph's nodes.</typeparam>
    /// <typeparam name="TEdgeValue">The type of value associated with edges in the graph.</typeparam>
    public class BreadthFirstSearcher<TNodeValue, TEdgeValue> : IGraphSearcher<TNodeValue, TEdgeValue>
    {
        private readonly IComparer<INode<TNodeValue, TEdgeValue>> comparer;
        
        public BreadthFirstSearcher(IComparer<INode<TNodeValue, TEdgeValue>> comparer = null)
        {
            this.comparer = comparer ?? new DefaultNodeComparer<TNodeValue, TEdgeValue>();
        }
        
        /// <summary>
        /// Conducts a breadth-first search within the specified graph starting from the given node.
        /// </summary>
        /// <param name="graph">The graph in which the search operation will be performed.</param>
        /// <param name="startNode">The node from which the search will begin.</param>
        /// <returns>An enumerable collection of nodes traversed during the search operation.</returns>
        public IEnumerable<INode<TNodeValue, TEdgeValue>> Search(IGraph<TNodeValue, TEdgeValue> graph, INode<TNodeValue, TEdgeValue> startNode)
        {
            var queue = new Queue<INode<TNodeValue, TEdgeValue>>();
            var visited = new HashSet<INode<TNodeValue, TEdgeValue>>();

            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                yield return current;

                var neighbors = current.GetNeighbors().ToList();
                
                if (this.comparer != null)
                {
                    neighbors.Sort(this.comparer);
                }
                
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }
    }
}
