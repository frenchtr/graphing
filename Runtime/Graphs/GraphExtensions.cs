using System.Linq;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    /// <summary>
    /// Provides extension methods for IGraph&lt;TNodeValue, TEdgeValue&gt; to simplify common operations.
    /// </summary>
    public static class GraphExtensions
    {
        /// <summary>
        /// Adds a new node with the specified value to the graph and returns the newly created node.
        /// </summary>
        /// <typeparam name="TNodeValue">The type of the node's value.</typeparam>
        /// <typeparam name="TEdgeValue">The type of the edge's value.</typeparam>
        /// <param name="graph">The graph to which the node will be added.</param>
        /// <param name="value">The value of the node to add.</param>
        /// <returns>The newly created node.</returns>
        public static INode<TNodeValue, TEdgeValue> AddNode<TNodeValue, TEdgeValue>(this IGraph<TNodeValue, TEdgeValue> graph, TNodeValue value)
        {
            var node = new Node<TNodeValue, TEdgeValue>(graph, value);
            graph.AddNode(node);

            return node;
        }

        /// <summary>
        /// Adds a new edge between the specified nodes to the graph, with an optional weight and value, and returns the newly created edge.
        /// </summary>
        /// <typeparam name="TNodeValue">The type of the node's value.</typeparam>
        /// <typeparam name="TEdgeValue">The type of the edge's value.</typeparam>
        /// <param name="graph">The graph to which the edge will be added.</param>
        /// <param name="first">The first node connected by the edge.</param>
        /// <param name="second">The second node connected by the edge.</param>
        /// <param name="weight">The weight of the edge. Defaults to the default value of float if not provided.</param>
        /// <param name="value">The value associated with the edge. Defaults to the default value of TEdgeValue if not provided.</param>
        /// <returns>The newly created edge.</returns>
        public static IEdge<TNodeValue, TEdgeValue> AddEdge<TNodeValue, TEdgeValue>(this IGraph<TNodeValue, TEdgeValue> graph, INode<TNodeValue, TEdgeValue> first, INode<TNodeValue, TEdgeValue> second, float weight = default, TEdgeValue value = default)
        {
            var edge = new Edge<TNodeValue, TEdgeValue>(graph, first, second, value);
            
            graph.AddEdge(edge);

            return edge;
        }

        /// <summary>
        /// Removes the edge between the specified nodes from the graph, if such an edge exists.
        /// </summary>
        /// <typeparam name="TNodeValue">The type of the node's value.</typeparam>
        /// <typeparam name="TEdgeValue">The type of the edge's value.</typeparam>
        /// <param name="graph">The graph from which the edge will be removed.</param>
        /// <param name="first">The first node connected by the edge.</param>
        /// <param name="second">The second node connected by the edge.</param>
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
