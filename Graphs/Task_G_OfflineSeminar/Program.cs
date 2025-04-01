using System;
using System.Collections.Generic;

namespace Task_G_OfflineSeminar
{
    class Program
    {
        static int[,] FloydWarshall(int n, List<(int u, int v, int w)> roads)
        {
            var dist = new int[n + 1, n + 1];
            for (var i = 1; i <= n; i++)
                for (var j = 1; j <= n; j++)
                    dist[i, j] = (i == j) ? 0 : int.MaxValue;

            foreach (var (u, v, w) in roads)
            {
                dist[u, v] = w;
                dist[v, u] = w;
            }

            for (var k = 1; k <= n; k++)
                for (var i = 1; i <= n; i++)
                    for (var j = 1; j <= n; j++)
                        if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue)
                            dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);

            return dist;
        }

        static int FindOptimalCity(int n, int[,] dist)
        {
            var minTotalDistance = int.MaxValue;
            var optimalCity = -1;

            for (var i = 1; i <= n; i++)
            {
                var totalDistance = 0;
                for (var j = 1; j <= n; j++)
                    if (i != j && dist[i, j] != int.MaxValue)
                        totalDistance = Math.Max(totalDistance, dist[i, j]);

                if (totalDistance < minTotalDistance)
                {
                    minTotalDistance = totalDistance;
                    optimalCity = i;
                }
            }
            return optimalCity;
        }

        static void Main()
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(input[0]);
            var m = int.Parse(input[1]);
            var roads = new List<(int, int, int)>();

            for (var i = 0; i < m; i++)
            {
                var roadData = Console.ReadLine().Split();
                roads.Add((int.Parse(roadData[0]), int.Parse(roadData[1]), int.Parse(roadData[2])));
            }

            var distances = FloydWarshall(n, roads);
            Console.WriteLine(FindOptimalCity(n, distances));
        }
    }
}