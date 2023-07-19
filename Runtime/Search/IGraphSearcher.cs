public interface IGraphSearcher
{
    IEnumerable<INode<TValue>> Search<TValue>(IGraph<TValue> graph, INode<TValue> startNode);
}
