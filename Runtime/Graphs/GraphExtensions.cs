using System.Linq;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    public static class GraphExtensions
    {
        public static INode<TNodeValue, TEdgeValue> AddNode<TNodeValue, TEdgeValue>(this IGraph<TNodeValue, TEdgeValue> graph, TNodeValue value)
        {
            var node = new Node<TNodeValue, TEdgeValue>(graph, value);
            graph.AddNode(node);

            return node;
        }

        public static IEdge<TNodeValue, TEdgeValue> AddEdge<TNodeValue, TEdgeValue>(this IGraph<TNodeValue, TEdgeValue> graph, INode<TNodeValue, TEdgeValue> first, INode<TNodeValue, TEdgeValue> second, float weight = default, TEdgeValue value = default)
        {
            var edge = new Edge<TNodeValue, TEdgeValue>(graph, first, second, value);
            
            graph.AddEdge(edge);

            return edge;
        }

        public static void RemoveEdge<TNodeValue, TEdgeValue>(this IGraph<TNodeValue, TEdgeValue> graph, INode<TNodeValue, TEdgeValue> first, INode<TNodeValue, TEdgeValue> second)
        {
            var edgeToRemove = graph.Edges
                .FirstOrDefault(edge => (edge.First == first && edge.Second == second) || (edge.First == second && edge.Second == first));
            
            if (edgeToRemove != null)
            {
                graph.RemoveEdge(edgeToRemove);
            }
        }
    }
}
