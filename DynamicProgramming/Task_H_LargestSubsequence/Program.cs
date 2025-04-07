using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_H_LargestSubsequence
{
    class Program
    {
        static (List<int> sequence, int length) LargestIncreasingSubsequence(int[] a, int n)
        {
            var prev = new int[n];
            var dp = new int[n];
            
            for (var i = 0; i < n; i++)
            {
                prev[i] = -1;
                dp[i] = 1;
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (a[i] > a[j] && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                        prev[i] = j;
                    }
                }
            }

            var lastIndex = 0;
            var maxLength = dp[0];
            for (var i = 1; i < n; i++)
            {
                if (dp[i] > maxLength)
                {
                    maxLength = dp[i];
                    lastIndex = i;
                }
            }

            var sequence = new List<int>();
            while (lastIndex >= 0)
            {
                sequence.Add(a[lastIndex]);
                lastIndex = prev[lastIndex];
            }
            sequence.Reverse();

            return (sequence, maxLength);
        }

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine()
                          .Split()
                          .Select(int.Parse)
                          .ToArray();

            var result = LargestIncreasingSubsequence(a, n);
            Console.WriteLine(result.length);
            Console.WriteLine(string.Join(" ", result.sequence));
        }
    }
}