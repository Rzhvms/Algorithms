using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_C_CollectCoins
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(input[0]);
            var k = int.Parse(input[1]);

            var coins = new List<int> { 0 }
                .Concat(Console.ReadLine().Split().Select(int.Parse))
                .Concat(new[] { 0 })
                .ToArray();
            
            n -= 1;
            var dp = new int[n + 1];
            var prevStolbik = new int[n + 1];
            var dequeMax = new LinkedList<int>();
            dequeMax.AddFirst(0);

            for (var i = 1; i <= n; i++)
            {
                while (dequeMax.Count > 0 && dequeMax.First.Value < i - k)
                    dequeMax.RemoveFirst();

                var maxIndex = dequeMax.First.Value;
                var maxValue = dp[maxIndex] + coins[i];

                dp[i] = maxValue;
                prevStolbik[i] = maxIndex;

                while (dequeMax.Count > 0 && dp[i] >= dp[dequeMax.Last.Value])
                    dequeMax.RemoveLast();
                
                dequeMax.AddLast(i);
            }

            var path = new List<int>();
            var currentStolbik = n;
            while (currentStolbik != 0)
            {
                path.Add(currentStolbik);
                currentStolbik = prevStolbik[currentStolbik];
            }
            path.Add(0);
            path.Reverse();

            Console.WriteLine(dp[n]);
            Console.WriteLine(path.Count - 1);
            Console.WriteLine(string.Join(" ", path.Select(x => x + 1)));
        }
    }
}