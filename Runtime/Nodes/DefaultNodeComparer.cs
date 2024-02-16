using System.Collections.Generic;

namespace TravisRFrench.Graphing.Runtime.Nodes
{
    public class DefaultNodeComparer<TNodeValue, TEdgeValue> : IComparer<INode<TNodeValue, TEdgeValue>>
    {
        public int Compare(INode<TNodeValue, TEdgeValue> first, INode<TNodeValue, TEdgeValue> second)
        {
            // Handle null nodes
            if (first == null)
            {
                if (second == null)
                {
                    // Both nodes are null, consider them equal
                    return 0;
                }
                else
                {
                    // Only the first node is null, consider it less than the second node
                    return -1;
                }
            }
            else if (second == null)
            {
                // Only the second node is null, consider it greater than the first node
                return 1;
            }

            // Compare the hash codes of the values of the two nodes
            return first.Value.GetHashCode().CompareTo(second.GetHashCode());
        }
    }
}
