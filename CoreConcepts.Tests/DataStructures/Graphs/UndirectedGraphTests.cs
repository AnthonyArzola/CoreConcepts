using System;
using System.Collections.Generic;
using System.Text;

using CoreConcepts.DataStructures.Graphs;

using Xunit;

namespace CoreConcepts.Tests.DataStructures.Graphs
{
    public class UndirectedGraphTests
    {
        [Fact]
        public void Test_Undirected_Graph_BFS()
        {
            // Define vertices
            int[] vertices = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Define edges
            (int leftVertex, int rightVertex)[] edges = new[] {
                (1,2), (1,3),
                (2,4), (3,5),
                (3,6), (4,7),
                (5,7), (5,8),
                (5,6), (8,9),
                (9,10)};

            UndirectedGraph graph = new UndirectedGraph(vertices, edges);

            var (vertexFound, visitedVertices) = graph.BreadthFirstSearch(1, 6);
            Assert.True(vertexFound);
            Assert.NotEmpty(visitedVertices);
            Console.WriteLine("BFT:");
            Console.WriteLine(ListToString(visitedVertices));
        }

        [Fact]
        public void Test_Undirected_Graph_DFS()
        {
            // Define vertices
            int[] vertices = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Define edges
            (int leftVertex, int rightVertex)[] edges = new[] {
                (1,2), (1,3),
                (2,4), (3,5),
                (3,6), (4,7),
                (5,7), (5,8),
                (5,6), (8,9),
                (9,10)};

            UndirectedGraph graph = new UndirectedGraph(vertices, edges);
            var (vertexFound, visitedVertices) = graph.DepthFirstSearch(1, 10);
            Assert.True(vertexFound);
            Assert.NotEmpty(visitedVertices);
        }

        public static string ListToString(List<int> list)
        {
            StringBuilder sb = new StringBuilder("{");
            foreach (int item in list)
            {
                sb.Append($" {item} ");
            }
            sb.Append("}");

            return sb.ToString();
        }

    }
}
