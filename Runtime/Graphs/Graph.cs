using System;
using System.Collections.Generic;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    public abstract class Graph<TNodeValue, TEdgeValue> : IGraph<TNodeValue, TEdgeValue>
    {
        protected readonly List<INode<TNodeValue, TEdgeValue>> nodes;
        protected readonly List<IEdge<TNodeValue, TEdgeValue>> edges;
        
        public Guid ID { get; }
        public IEnumerable<INode<TNodeValue, TEdgeValue>> Nodes => this.nodes.AsReadOnly();
        public IEnumerable<IEdge<TNodeValue, TEdgeValue>> Edges => this.edges.AsReadOnly();

        protected Graph(Guid id)
        {
            this.ID = id;
            this.nodes = new List<INode<TNodeValue, TEdgeValue>>();
            this.edges = new List<IEdge<TNodeValue, TEdgeValue>>();
        }

        protected Graph()
            : this(Guid.NewGuid())
        {
        }

        public abstract void AddNode(INode<TNodeValue, TEdgeValue> node);
        public abstract void RemoveNode(INode<TNodeValue, TEdgeValue> node);
        public abstract void AddEdge(IEdge<TNodeValue, TEdgeValue> edge);
        public abstract void RemoveEdge(IEdge<TNodeValue, TEdgeValue> edge);
    }
}
