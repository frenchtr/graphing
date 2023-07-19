using System;
using System.Collections.Generic;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Runtime.Graphs
{
    public abstract class Graph<TValue> : IGraph<TValue>
    {
        protected readonly List<INode<TValue>> nodes;
        protected readonly List<IEdge<TValue>> edges;
        
        public Guid ID { get; }
        public IEnumerable<INode<TValue>> Nodes => this.nodes.AsReadOnly();
        public IEnumerable<IEdge<TValue>> Edges => this.edges.AsReadOnly();

        protected Graph(Guid id)
        {
            this.ID = id;
            this.nodes = new List<INode<TValue>>();
            this.edges = new List<IEdge<TValue>>();
        }

        protected Graph()
            : this(Guid.NewGuid())
        {
        }

        public abstract void AddNode(INode<TValue> node);
        public abstract void RemoveNode(INode<TValue> node);
        public abstract void AddEdge(IEdge<TValue> edge);
        public abstract void RemoveEdge(IEdge<TValue> edge);
    }
}
