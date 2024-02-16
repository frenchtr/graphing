using System;
using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    public class DirectedGraph<TNodeValue, TEdgeValue> : Graph<TNodeValue, TEdgeValue>
    {
        public DirectedGraph(Guid id)
            : base(id)
        {
        }

        public DirectedGraph()
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
            if (edge.First.Graph != this || edge.Second.Graph != this)
            {
                throw new InvalidOperationException($"Cannot add edge to node on a different graph.");
            }
            
            this.edges.Add(edge);
        }
        
        public override void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge)
        {
            this.edges.Remove(edge);
        }
    }
}
