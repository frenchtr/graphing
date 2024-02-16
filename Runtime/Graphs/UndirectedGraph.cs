using System;
using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    public class UndirectedGraph<TNodeValue, TEdgeValue> : Graph<TNodeValue, TEdgeValue>
    {
        public UndirectedGraph(Guid id)
            : base(id)
        {
        }
        
        public UndirectedGraph()
        {
        }
        
        public override void AddNode(INode<TNodeValue, TEdgeValue> node)
        {
            this.nodes.Add(node);
        }

        public override void RemoveNode(INode<TNodeValue, TEdgeValue> node)
        {
            var edgesToRemove = new List<IEdge<TNodeValue, TEdgeValue>>(this.edges.Where(e => e.First == node || e.Second == node));
            foreach (var edge in edgesToRemove)
            {
                this.edges.Remove(edge);
            }
            
            this.nodes.Remove(node);
        }
        
        public override void AddEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            // In an undirected graph, adding an edge implicitly adds the "inverse" edge.
            // However, since the edge now contains a value, you may need to decide how to handle this:
            // For example, should the inverse edge share the same value or have a different one?
            // The implementation below assumes the inverse edge shares the same value.
            var inverseEdge = new Edge<TNodeValue, TEdgeValue>(
                Guid.NewGuid(), 
                this, 
                edge.Second, 
                edge.First, 
                edge.Value);

            this.edges.Add(edge);
            this.edges.Add(inverseEdge);
        }

        public override void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            // In removing an edge in an undirected graph, also remove the "inverse" edge.
            var inverseEdge = this.edges.FirstOrDefault(e => e.First == edge.Second && e.Second == edge.First && Equals(e.Value, edge.Value));
            if (edge != null) this.edges.Remove(edge);
            if (inverseEdge != null) this.edges.Remove(inverseEdge);
        }
    }
}
