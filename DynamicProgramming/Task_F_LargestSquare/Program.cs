using System;
using System.Linq;

namespace Task_F_LargestSquare
{
    class Program
    {
        static (int maxSide, int topLeftX, int topLeftY) FindLargestSquare(int n, int m, int[][] grid)
        {
            var dp = new int[n][];
            for (var i = 0; i < n; i++)
                dp[i] = new int[m];

            var maxSide = 0;
            var maxX = 0;
            var maxY = 0;

            for (var x = 0; x < n; x++)
            {
                for (var y = 0; y < m; y++)
                {
                    if (grid[x][y] == 1)
                    {
                        if (x == 0 || y == 0)
                        {
                            dp[x][y] = 1;
                        }
                        else
                        {
                            dp[x][y] = Math.Min(Math.Min(dp[x - 1][y], dp[x][y - 1]), dp[x - 1][y - 1]) + 1;
                        }

                        if (dp[x][y] >= maxSide)
                        {
                            maxSide = dp[x][y];
                            maxX = x;
                            maxY = y;
                        }
                    }
                }
            }

            return (maxSide, maxX - maxSide + 1, maxY - maxSide + 1);
        }

        static void Main()
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(input[0]);
            var m = int.Parse(input[1]);

            var field = new int[n][];
            for (var i = 0; i < n; i++)
            {
                field[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            var (maxSide, topLeftX, topLeftY) = FindLargestSquare(n, m, field);
            Console.WriteLine(maxSide);
            Console.WriteLine($"{topLeftX + 1} {topLeftY + 1}");
        }
    }
}