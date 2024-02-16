using NUnit.Framework;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Tests.EditMode
{
    [TestFixture]
    public class EdgeTests
    {
        private IGraph<string, int> graph;
        private INode<string, int> firstNode;
        private INode<string, int> secondNode;
        
        [SetUp]
        public void SetUp()
        {
            this.graph = new DirectedGraph<string, int>();
            this.firstNode = new Node<string, int>(this.graph, "First");
            this.secondNode = new Node<string, int>(this.graph, "Second");
        }

        [Test]
        public void GivenEdge_WhenCreated_ShouldCorrectlyReferenceGraphAndNodes()
        {
            // Given is in SetUp

            // When
            var edge = new Edge<string, int>(this.graph, this.firstNode, this.secondNode, 100);

            // Then
            Assert.AreEqual(this.graph, edge.Graph, "Edge should reference the correct graph.");
            Assert.AreEqual(this.firstNode, edge.First, "Edge should reference the correct first node.");
            Assert.AreEqual(this.secondNode, edge.Second, "Edge should reference the correct second node.");
            Assert.AreEqual(100, edge.Value, "Edge should hold the correct value.");
        }

        [Test]
        public void GivenEdge_WhenValueIsSet_ShouldReflectNewValue()
        {
            // Given
            var edge = new Edge<string, int>(this.graph, this.firstNode, this.secondNode, default);
            var newValue = 200;

            // When
            edge.Value = newValue;

            // Then
            Assert.AreEqual(newValue, edge.Value, "Edge's value should be updated to the new value.");
        }

        [Test]
        public void GivenTwoEdges_WhenCreated_ShouldHaveUniqueIds()
        {
            // Given is in SetUp

            // When
            var edge1 = new Edge<string, int>(this.graph, this.firstNode, this.secondNode, 100);
            var edge2 = new Edge<string, int>(this.graph, this.firstNode, this.secondNode, 200);

            // Then
            Assert.AreNotEqual(edge1.ID, edge2.ID, "Each edge should have a unique ID.");
        }
    }
}
