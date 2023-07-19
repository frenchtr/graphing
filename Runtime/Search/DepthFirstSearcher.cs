using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Graphs;
using TravisRFrench.Graphing.Nodes;

namespace DemoCode.Runtime.Search;

public class DepthFirstSearcher : IGraphSearcher
{
    public IEnumerable<INode<TValue>> Search<TValue>(IGraph<TValue> graph, INode<TValue> startNode)
    {
        var stack = new Stack<INode<TValue>>();
        var visited = new List<INode<TValue>>();
        
        stack.Push(startNode);

        while (stack.Any())
        {
            var current = stack.Pop();
            
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
                if (stack.Any(n => n == neighbor))
                {
                    continue;
                }

                stack.Push(neighbor);
            }
            
            yield return current;
        }
    }
}
