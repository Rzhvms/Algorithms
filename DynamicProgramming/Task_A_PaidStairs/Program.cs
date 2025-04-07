using System;
using System.Linq;

namespace Task_A_PaidStairs
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var ladder = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (n == 1)
            {
                Console.WriteLine(ladder[0]);
                return;
            }

            var dp = new int[n + 1];
            dp[1] = dp[0] + ladder[0];

            for (int i = 2; i <= n; i++)
            {
                dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + ladder[i - 1];
            }

            Console.WriteLine(dp[n]);
        }
    }
}