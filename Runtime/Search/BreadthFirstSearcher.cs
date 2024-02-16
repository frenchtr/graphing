using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Search
{
    public class BreadthFirstSearcher<TNodeValue, TEdgeValue> : IGraphSearcher<TNodeValue, TEdgeValue>
    {
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

                var neighbors = current.GetNeighbors();
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
