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

        public UndirectedGraph(int[] vertices, IEnumerable<(int leftVertex, int rightVertex)> edges)
        {
            AdjacencyList = new Dictionary<int, HashSet<int>>();

            foreach (int vertex in vertices)
            {
                AddVertex(vertex);
            }

            foreach ((int leftV, int rightV) edge in edges)
            {
                AddEdge(edge);
            }
        }

        #endregion

        #region Private Methods

        private void AddVertex(int vertex)
        {
            if (!AdjacencyList.ContainsKey(vertex))
            {
                AdjacencyList.Add(vertex, new HashSet<int>());
                //Console.WriteLine($"Added vertex {vertex}");
            }
        }

        private void AddEdge((int leftVertex, int rightVertex) edge)
        {
            // Since we are modeling undirected graph,
            // record both side of the edge/connection
            if (AdjacencyList.ContainsKey(edge.leftVertex) && !AdjacencyList[edge.leftVertex].Contains(edge.rightVertex))
            {
                AdjacencyList[edge.leftVertex].Add(edge.rightVertex);
                //Console.WriteLine($"Vertex {edge.leftVertex}: added edge {edge.rightVertex}");
            }

            if (AdjacencyList.ContainsKey(edge.rightVertex) && !AdjacencyList[edge.rightVertex].Contains(edge.leftVertex))
            {
                AdjacencyList[edge.rightVertex].Add(edge.leftVertex);
                //Console.WriteLine($"Vertex {edge.rightVertex}: added edge {edge.leftVertex}");
            }
        }

        #endregion

        #region Public Methods

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

        /// <summary>
        /// Searches graph by performing depth-first-search.
        /// </summary>
        /// <param name="startingVertex">Initial vertex.</param>
        /// <param name="findVertex">Vertex to search for.</param>
        /// <returns>Tuple indicating if vertex was found and vertices searched.</returns>
        public (bool vertexFound, List<int> visitedVertices) DepthFirstSearch(int startingVertex, int findVertex)
        {
            // Keep track of visited vertices
            List<int> visited = new List<int>();
            bool vertexFound = false;

            // Guard against vertex that doesn't exist
            if (!AdjacencyList.ContainsKey(startingVertex))
                return (vertexFound, visited);

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

            return (vertexFound, visited);
        }

        /// <summary>
        /// Traverses graph using breadth-first approach.
        /// </summary>
        /// <param name="startingVertex">Starting vertex.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Searches graph by performing breadth-first-search.
        /// </summary>
        /// <param name="startingVertex">Starting vertex.</param>
        /// <param name="findVertex">Vertex to search for.</param>
        /// <returns></returns>
        public (bool vertexFound, List<int> visitedVertices) BreadthFirstSearch(int startingVertex, int findVertex)
        {
            // Keep track of visited vertices
            List<int> visited = new List<int>();
            bool vertexFound = false;

            // Guard against vertex not in the graph
            if (!AdjacencyList.ContainsKey(startingVertex))
                return (vertexFound, visited);

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

            return (vertexFound, visited);
        }

        #endregion
    }

}

