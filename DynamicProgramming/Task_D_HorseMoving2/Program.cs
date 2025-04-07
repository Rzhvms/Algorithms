using System;

namespace Task_D_HorseMoving2
{
    class Program
    {
        static long GetMove(int n, int m)
        {
            var dp = new long[n + 3, m + 3];
            dp[2, 2] = 1;
            var startX = 2;
            var startY = 2;
            
            while (startX < n + 1 || startY < m + 1)
            {
                if (startY == m + 1)
                    startX++;
                else
                    startY++;

                var x = startX;
                var y = startY;
                
                while (x <= n + 1 && y >= 2)
                {
                    dp[x, y] = dp[x + 1, y - 2] + dp[x - 1, y - 2] 
                             + dp[x - 2, y - 1] + dp[x - 2, y + 1];
                    x++;
                    y--;
                }
            }
            
            return dp[n + 1, m + 1];
        }

        static void Main()
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(input[0]);
            var m = int.Parse(input[1]);
            
            Console.WriteLine(GetMove(n, m));
        }
    }
}