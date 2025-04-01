using System;
using System.Collections.Generic;

namespace Task_B_Cycle
{
    class Program
    {
        static bool DFS(int v, Dictionary<int, bool> visited, Dictionary<int, bool> recursionStack, Dictionary<int, List<int>> graph)
        {
            visited[v] = true;
            recursionStack[v] = true;

            if (graph.ContainsKey(v))
            {
                foreach (var neighbour in graph[v])
                {
                    if (!visited.ContainsKey(neighbour) 
                        || !visited[neighbour])
                    {
                        if (DFS(neighbour, visited, recursionStack, graph))
                            return true;
                    }
                    else if (recursionStack.ContainsKey(neighbour) 
                            && recursionStack[neighbour])
                    {
                        return true;
                    }
                }
            }

            recursionStack[v] = false;
            return false;
        }

        static bool IsCyclic(int n, Dictionary<int, List<int>> graph)
        {
            var visited = new Dictionary<int, bool>();
            var recursionStack = new Dictionary<int, bool>();

            for (var i = 1; i <= n; i++)
            {
                if (!visited.ContainsKey(i) || !visited[i])
                {
                    if (DFS(i, visited, recursionStack, graph))
                        return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(input[0]);
            var m = int.Parse(input[1]);

            var graph = new Dictionary<int, List<int>>();

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine().Split();
                var u = int.Parse(edge[0]);
                var v = int.Parse(edge[1]);

                if (!graph.ContainsKey(u))
                    graph[u] = new List<int>();

                graph[u].Add(v);
            }

            Console.WriteLine(IsCyclic(n, graph) ? 1 : 0);
        }
    }
}