using System;
using System.Collections.Generic;

namespace Task_F_Subpalindrome
{
    class program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            Console.WriteLine(CountPalindromes(input));
        }

        static long CountPalindromes(string s)
        {
            int n = s.Length;
            if (n == 0) return 0;

            char[] t = new char[2 * n + 3];
            t[0] = '$';
            t[1] = '#';
            for (int i = 0; i < n; i++)
            {
                t[2 * i + 2] = s[i];
                t[2 * i + 3] = '#';
            }
            t[2 * n + 2] = '@';

            int[] p = new int[t.Length];
            int center = 0, right = 0;
            long count = 0;

            for (int i = 1; i < t.Length - 1; i++)
            {
                int mirror = 2 * center - i;
            
                if (i < right)
                    p[i] = Math.Min(right - i, p[mirror]);
            
                while (t[i + (1 + p[i])] == t[i - (1 + p[i])])
                    p[i]++;
            
                if (i + p[i] > right)
                {
                    center = i;
                    right = i + p[i];
                }
            
                count += (p[i] + 1) / 2;
            }

            return count;
        }
    }
}