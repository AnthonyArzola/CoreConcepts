using System;
using System.Collections.Generic;
using System.Text;

namespace CoreConcepts.DataStructures.Graphs
{
    public class UndirectedGraph
    {
        #region Data Members

        private Dictionary<int, HashSet<int>> AdjacencyList { get; set; }

        #endregion

        #region Creation

        public UndirectedGraph(int[] vertices, IEnumerable<Tuple<int, int>> edges)
        {
            AdjacencyList = new Dictionary<int, HashSet<int>>();

            foreach (int vertex in vertices)
            {
                AddVertex(vertex);
            }

            foreach (Tuple<int, int> edge in edges)
            {
                AddEdge(edge);
            }
        }

        #endregion

        #region Methods

        public void AddVertex(int vertex)
        {
            if (!AdjacencyList.ContainsKey(vertex))
            {
                AdjacencyList.Add(vertex, new HashSet<int>());
                //Console.WriteLine($"Added vertex {vertex}");
            }
        }

        public void AddEdge(Tuple<int, int> edge)
        {
            // Since we are modeling undirected graph,
            // record both side of the edge/connection
            if (AdjacencyList.ContainsKey(edge.Item1) && !AdjacencyList[edge.Item1].Contains(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                //Console.WriteLine($"Vertex {edge.Item1}: added edge {edge.Item2}");
            }

            if (AdjacencyList.ContainsKey(edge.Item2) && !AdjacencyList[edge.Item2].Contains(edge.Item1))
            {
                AdjacencyList[edge.Item2].Add(edge.Item1);
                //Console.WriteLine($"Vertex {edge.Item2}: added edge {edge.Item1}");
            }
        }

        public string VerticesAndEdgesToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in AdjacencyList.Keys)
            {
                sb.Append($"{key}: ");
                foreach (int edge in AdjacencyList[key])
                {
                    sb.Append($"{edge} ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public Tuple<bool, List<int>> DepthFirstSearch(int startingVertex, int findVertex)
        {
            // Keep track of visited vertices
            List<int> visited = new List<int>();
            bool vertexFound = false;

            // Guard against vertex that doesn't exist
            if (!AdjacencyList.ContainsKey(startingVertex))
                return Tuple.Create(vertexFound, visited);

            // Use stack to track vertices found, but not visisted yet
            Stack<int> stack = new Stack<int>();
            stack.Push(startingVertex);

            while (stack.Count > 0)
            {
                // Process current vertex
                int vertex = stack.Pop();

                // Skip previously visited vertex
                if (visited.Contains(vertex))
                    continue;

                // Mark current vertex as visited
                visited.Add(vertex);

                // If we found a match, break out and return path
                if (vertex == findVertex)
                {
                    vertexFound = true;
                    break;
                }

                // Process edges for current vertex
                foreach (int neighbor in AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                        stack.Push((neighbor));
                }
            }

            return Tuple.Create(vertexFound, visited);
        }

        public List<int> BreadthFirstTraversal(int startingVertex)
        {
            // Keep track of visited vertices
            List<int> visited = new List<int>();

            // Guard against vertex not in the graph
            if (!AdjacencyList.ContainsKey(startingVertex))
                return visited;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startingVertex);

            while (queue.Count > 0)
            {
                // Process next vertex in the queue
                int vertex = queue.Dequeue();

                // Skip previously processed vertex
                if (visited.Contains(vertex))
                    continue;

                // Mark as visited
                visited.Add(vertex);

                // Process edges for current vertex
                foreach (int neighbor in AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
            }

            return visited;
        }

        public Tuple<bool, List<int>> BreadthFirstSearch(int startingVertex, int findVertex)
        {
            // Keep track of visited vertices
            List<int> visited = new List<int>();
            bool vertexFound = false;

            // Guard against vertex not in the graph
            if (!AdjacencyList.ContainsKey(startingVertex))
                return Tuple.Create(vertexFound, visited);

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startingVertex);

            while (queue.Count > 0)
            {
                // Process next vertex in the queue
                int vertex = queue.Dequeue();

                // Skip previously processed vertex
                if (visited.Contains(vertex))
                    continue;

                // Mark as visited
                visited.Add(vertex);

                // If we found a match, break out and return path
                if (vertex == findVertex)
                {
                    vertexFound = true;
                    break;
                }

                // Process edges for current vertex
                foreach (int neighbor in AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
            }

            return Tuple.Create(vertexFound, visited);
        }

        #endregion
    }

}

