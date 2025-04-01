using System;
using System.Collections.Generic;

namespace Task_C_TopologicalSorting
{
    class Program
    {
        static string IsTopologicalSort(List<int> permutation, Dictionary<int, List<int>> graph, int n)
        {
            var position = new Dictionary<int, int>();
            for (int i = 0; i < permutation.Count; i++)
            {
                position[permutation[i]] = i;
            }

            for (int u = 1; u <= n; u++)
            {
                if (graph.ContainsKey(u))
                {
                    foreach (var v in graph[u])
                    {
                        if (position[u] > position[v])
                        {
                            return "NO";
                        }
                    }
                }
            }
            return "YES";
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            var edges = new List<Tuple<int, int>>();
            for (int i = 0; i < m; i++)
            {
                var edgeInput = Console.ReadLine().Split();
                edges.Add(Tuple.Create(
                    int.Parse(edgeInput[0]), 
                    int.Parse(edgeInput[1])));
            }

            var permutationInput = Console.ReadLine().Split();
            var permutation = new List<int>();
            foreach (var num in permutationInput)
            {
                permutation.Add(int.Parse(num));
            }

            var graph = new Dictionary<int, List<int>>();
            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge.Item1))
                {
                    graph[edge.Item1] = new List<int>();
                }
                graph[edge.Item1].Add(edge.Item2);
            }

            Console.WriteLine(IsTopologicalSort(permutation, graph, n));
        }
    }
}