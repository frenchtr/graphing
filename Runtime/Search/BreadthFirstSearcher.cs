using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Graphs;
using TravisRFrench.Graphing.Nodes;

namespace DemoCode.Runtime.Search;

public class BreadthFirstSearcher : IGraphSearcher
{
    public IEnumerable<INode<TValue>> Search<TValue>(IGraph<TValue> graph, INode<TValue> startNode)
    {
        var queue = new Queue<INode<TValue>>();
        var visited = new List<INode<TValue>>();
        
        queue.Enqueue(startNode);

        while (queue.Any())
        {
            var current = queue.Dequeue();
            
            visited.Add(current);

            var neighbors = current.GetNeighbors();
            foreach (var neighbor in neighbors)
            {
                // Skip this neighbor if it's already in the visited list
                if (visited.Any(n => n == neighbor))
                {
                    continue;
                }
                
                // Skip this neighbor if it's already queued
                if (queue.Any(n => n == neighbor))
                {
                    continue;
                }

                queue.Enqueue(neighbor);
            }
            
            yield return current;
        }
    }
}
