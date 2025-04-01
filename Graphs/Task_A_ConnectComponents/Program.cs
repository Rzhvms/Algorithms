using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_A_ConnectComponents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var N_M = Console.ReadLine().Split(' ');
            var N = int.Parse(N_M[0]);
            var M = int.Parse(N_M[1]);

            var gr = new Graph(N);

            for (var i = 0; i < M; i++)
            {
                var nn = Console.ReadLine().Split(' ');
                var n1 = int.Parse(nn[0]);
                var n2 = int.Parse(nn[1]);
                gr.AddEdge(n1, n2);
            }
            
            var ans = gr.calcComp();
            Console.WriteLine(ans.Count);
            
            foreach (var component in ans.OrderByDescending(c => c.Count).ThenBy(c => c[0]))
            {
                component.Sort();
                Console.WriteLine(component.Count);
                Console.WriteLine(string.Join(" ", component));
            }
        }
    }

    public class Graph
    {
        private List<List<int>> nodes = new List<List<int>>();

        public Graph(int N)
        {
            for (var i = 0; i <= N; i++)
            {
                nodes.Add(new List<int>());
            }
        }

        public void AddEdge(int Node1, int Node2)
        {
            nodes[Node1].Add(Node2);
            nodes[Node2].Add(Node1);
        }

        public List<List<int>> calcComp()
        {
            var comps = new List<List<int>>();
            var q = new Queue<int>();
            var visited = new Dictionary<int, bool>();

            for (var i = 1; i < nodes.Count; i++) 
            {
                var st = i;
                if (visited.ContainsKey(st))
                {
                    continue;
                }
                
                q.Enqueue(st);
                comps.Add(new List<int>());
                
                while (q.Count > 0)
                {
                    var cur = q.Dequeue();
                    if (visited.ContainsKey(cur))
                    {
                        continue;
                    }
                    
                    comps[^1].Add(cur);
                    visited[cur] = true;
                    
                    foreach (var node in nodes[cur])
                    {
                        if (!visited.ContainsKey(node))
                        {
                            q.Enqueue(node);
                        }
                    }
                }
            }

            return comps;
        }
    }
}