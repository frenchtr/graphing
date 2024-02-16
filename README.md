# Graphing Library for Unity

This Graphing Library is designed as a Unity package to facilitate creating and manipulating graphs directly within Unity projects. It offers a suite of algorithms for traversing and analyzing graph data, supporting both directed and undirected graphs with generic types for node and edge values. This makes it an ideal tool for a wide range of applications, from network analysis to pathfinding in game development environments.

## Features

- **Unity Integration**: Easily integrated into Unity projects as a package.
- **Generic Graph Implementation**: Flexible construction with generic types for node and edge values.
- **Breadth-First Searcher (BFS)**: Breadth-first traversal for analyzing graph structures.
- **Depth-First Searcher (DFS)**: Depth-first traversal for analyzing graph structures.
- **Graph and Node Operations**: Comprehensive support for adding, removing, and managing nodes and edges.
- **Customizable Node Comparison**: Versatile node comparison strategies for varied use cases.

## Installation

### Via Unity Package Manager

To install this Graphing Library in your Unity project, follow these steps:

1. Open your Unity project.
2. Go to `Window` > `Package Manager`.
3. Click the `+` button at the top left corner of the Package Manager window and select `Add package from git URL...`.
4. Enter the git URL: `https://github.com/frenchtr/graphing.git` and click 'Add'.
5. The Graphing Library will be downloaded and installed into your project automatically.

## Usage

### Building a graph

After installation, the Graphing Library can be used within your Unity scripts. Start by adding the necessary `using` statements at the top of your script files:

```csharp
using TravisRFrench.Graphing.Runtime.Graphs;
using TravisRFrench.Graphing.Runtime.Nodes;
using TravisRFrench.Graphing.Runtime.Edges;
using TravisRFrench.Graphing.Runtime.Search;
```

To create a graph, add nodes and edges, and execute a breadth-first search, you can use the following example as a guide:

```csharp
var graph = new DirectedGraph<string, int>();
var nodeA = graph.AddNode("Washington");
var nodeB = graph.AddNode("Oregon");
var edge = graph.AddEdge(nodeA, nodeB, 1);
// Continue adding nodes and edges as required
```

This library aims to provide a straightforward and powerful tool for graph operations within Unity, enhancing game development and other graph-based applications.

### Searching a graph

To search an existing graph, create a searcher and enumerate through the `Search()` method return value as you would with any other collection.

```csharp
var searcher = new BreadthFirstSearcher();

foreach (var node in searcher.Search())
{
    // Do something with the node
}
```

## Running tests
This package includes unit tests to ensure the reliability of its core functionalities. To run the tests:

Open the Unity Test Runner via `Window` `->` `General` `->` `Test Runner`.
Navigate to the `EditMode` tab.
Click Run All to execute all tests.

## Contributing
Contributions to the Graphing Library are welcome. Please follow the existing code style and add unit tests for any new or changed functionality. Submit pull requests for review.

## License
This package is available under the MIT License. See the `LICENSE.md` file for more details.
