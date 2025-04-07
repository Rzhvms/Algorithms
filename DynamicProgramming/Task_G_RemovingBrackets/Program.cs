using System;

namespace Task_G_RemovingBrackets
{
    class Program
    {
        static string BalancedSequence(string s)
        {
            var n = s.Length;
            var dp = new string[n, n];

            for (var i = 0; i < n; i++)
            {
                dp[i, i] = "";
            }

            for (var length = 2; length <= n; length++)
            {
                for (var l = 0; l < n - length + 1; l++)
                {
                    var r = l + length - 1;
                    dp[l, r] = "";

                    if ((s[l] == '(' && s[r] == ')') || 
                        (s[l] == '[' && s[r] == ']') || 
                        (s[l] == '{' && s[r] == '}'))
                    {
                        dp[l, r] = s[l] + dp[l + 1, r - 1] + s[r];
                    }

                    for (var k = l; k < r; k++)
                    {
                        if (dp[l, k].Length + dp[k + 1, r].Length > dp[l, r].Length)
                        {
                            dp[l, r] = dp[l, k] + dp[k + 1, r];
                        }
                    }
                }
            }

            return dp[0, n - 1];
        }

        static void Main()
        {
            var input = Console.ReadLine();
            var result = BalancedSequence(input);
            Console.WriteLine(result);
        }
    }
}