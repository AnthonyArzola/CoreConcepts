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
            Tuple<int, int>[] edges = new[] {
                Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5),
                Tuple.Create(3,6), Tuple.Create(4,7),
                Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9),
                Tuple.Create(9,10)};

            UndirectedGraph graph = new UndirectedGraph(vertices, edges);

            Tuple<bool, List<int>> dfsResult = graph.DepthFirstSearch(1, 6);
            Assert.True(dfsResult.Item1);
            Console.Write("DFS:");
            Console.WriteLine(ListToString(dfsResult.Item2));

            Tuple<bool, List<int>> bfsResult = graph.BreadthFirstSearch(1, 6);
            Assert.True(bfsResult.Item1);
            Console.WriteLine("BFT:");
            Console.WriteLine(ListToString(bfsResult.Item2));
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
