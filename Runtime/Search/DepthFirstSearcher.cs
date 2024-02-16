using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Search
{
    public class DepthFirstSearcher<TNodeValue, TEdgeValue> : IGraphSearcher<TNodeValue, TEdgeValue>
    {
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
