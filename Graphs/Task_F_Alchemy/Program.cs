using System;
using System.Collections.Generic;

namespace Task_F_Alchemy
{
    class Program
    {
        static int MinDistanceBFS(Dictionary<string, List<string>> graph, string start, string end)
        {
            var queue = new Queue<(string Node, int Depth)>();
            queue.Enqueue((start, 0));
            var visited = new Dictionary<string, int>();

            while (queue.Count > 0)
            {
                var (value, depth) = queue.Dequeue();
            
                if (!visited.ContainsKey(value))
                {
                    if (graph.ContainsKey(value))
                    {
                        foreach (var neighbor in graph[value])
                        {
                            queue.Enqueue((neighbor, depth + 1));
                        }
                    }
                    visited[value] = depth;
                }
                else if (visited[value] > depth + 1)
                {
                    visited[value] = depth + 1;
                }
            
                if (value == end)
                {
                    return visited[value];
                }
            }
        
            return -1;
        }

        static void Main()
        {
            var m = int.Parse(Console.ReadLine());
            var graph = new Dictionary<string, List<string>>();
        
            for (var i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                if (input.Length < 2)
                continue;
            
                var from = input[0];
                var to = input[1];
            
                if (!graph.ContainsKey(from))
                {
                    graph[from] = new List<string>();
                }
                graph[from].Add(to);
            }

            var start = Console.ReadLine();
            var end = Console.ReadLine();
        
            Console.WriteLine(MinDistanceBFS(graph, start, end));
        }
    }
}