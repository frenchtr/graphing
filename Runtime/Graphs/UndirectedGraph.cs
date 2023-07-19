using System;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    public class UndirectedGraph<TValue> : Graph<TValue>
    {
        public UndirectedGraph(Guid id)
            : base(id)
        {
        }
        
        public UndirectedGraph()
        {
        }
        
        public override void AddNode(INode<TValue> node)
        {
            this.nodes.Add(node);
        }

        public override void RemoveNode(INode<TValue> node)
        {
            this.nodes.Remove(node);
        }

        public override void AddEdge(IEdge<TValue> edge)
        {
            var inverse = new Edge<TValue>(this, edge.Second, edge.First);
            
            this.edges.Add(edge);
            this.edges.Add(inverse);
        }

        public override void RemoveEdge(IEdge<TValue> edge)
        {
            var inverse = this.Edges.FirstOrDefault(e => e.First == edge.Second && e.Second == edge.First);
            this.edges.Remove(edge);
            this.edges.Remove(inverse);
        }
    }
}
