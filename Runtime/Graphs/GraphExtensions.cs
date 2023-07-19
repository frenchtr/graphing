using System.Linq;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    public static class GraphExtensions
    {
        public static INode<TValue> AddNode<TValue>(this IGraph<TValue> graph, TValue value)
        {
            var node = new Node<TValue>(graph, value);
            graph.AddNode(node);

            return node;
        }

        public static IEdge<TValue> AddEdge<TValue>(this IGraph<TValue> graph, INode<TValue> first, INode<TValue> second, float weight = default)
        {
            var edge = new Edge<TValue>(graph, first, second, weight);
            
            graph.AddEdge(edge);

            return edge;
        }

        public static void RemoveEdge<TValue>(this IGraph<TValue> graph, INode<TValue> first, INode<TValue> second)
        {
            var edgeToRemove = graph.Edges.FirstOrDefault(edge => edge.First == first && edge.Second == second);
            
            graph.RemoveEdge(edgeToRemove);
        }

        public static IEdge<TValue> AddInverseEdge<TValue>(this IEdge<TValue> edge)
        {
            var inverse = new Edge<TValue>(edge.Graph, edge.Second, edge.First);
            edge.Graph.AddEdge(inverse);
            
            return inverse;
        }
    }
}
