using NUnit.Framework;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;

namespace TravisRFrench.Graphing.Tests.EditMode
{
    /// <summary>
    /// Contains unit tests for the <see cref="Edge{TNodeValue, TEdgeValue}"/> class.
    /// </summary>
    [TestFixture]
    public class EdgeTests
    {
        private IGraph<string, int> graph;
        private INode<string, int> firstNode;
        private INode<string, int> secondNode;
        
        /// <summary>
        /// Sets up the test environment by creating a directed graph and two nodes.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.graph = new DirectedGraph<string, int>();
            this.firstNode = new Node<string, int>(this.graph, "First");
            this.secondNode = new Node<string, int>(this.graph, "Second");
        }

        /// <summary>
        /// Verifies that an edge correctly references the graph and nodes it belongs to upon creation.
        /// </summary>
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

        /// <summary>
        /// Verifies that an edge reflects the new value when it is set.
        /// </summary>
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

        /// <summary>
        /// Verifies that two edges created in sequence have unique IDs.
        /// </summary>
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
