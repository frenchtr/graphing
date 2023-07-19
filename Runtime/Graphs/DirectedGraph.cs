using System;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    public class DirectedGraph<TValue> : Graph<TValue>
    {
        public DirectedGraph(Guid id)
            : base(id)
        {
        }

        public DirectedGraph()
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
            if (edge.First.Graph != this || edge.Second.Graph != this)
            {
                throw new InvalidOperationException($"Cannot add edge to node on a different graph.");
            }
            
            this.edges.Add(edge);
        }
        
        public override void RemoveEdge(IEdge<TValue> edge)
        {
            this.edges.Remove(edge);
        }
    }
}
