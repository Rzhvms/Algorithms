using System;

namespace Task_E_LevinshteinDistance
{
    class Program
    {
        static int DamerauLevenshteinDistance(string str1, string str2)
        {
            var len1 = str1.Length;
            var len2 = str2.Length;
            var dp = new int[len1 + 1, len2 + 1];

            for (var i = 0; i <= len1; i++)
            {
                for (var j = 0; j <= len2; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = 1 + Math.Min(
                            Math.Min(dp[i - 1, j], dp[i, j - 1]),
                            dp[i - 1, j - 1]);

                        if (i > 1 && j > 1 && 
                            str1[i - 1] == str2[j - 2] && 
                            str1[i - 2] == str2[j - 1])
                        {
                            dp[i, j] = Math.Min(dp[i, j], dp[i - 2, j - 2] + 1);
                        }
                    }
                }
            }

            return dp[len1, len2];
        }

        static void Main()
        {
            var a = Console.ReadLine();
            var b = Console.ReadLine();
            
            Console.WriteLine(DamerauLevenshteinDistance(a, b));
        }
    }
}