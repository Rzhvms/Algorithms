using System;
using System.Collections.Generic;

namespace Task_A_CompareSubstring
{
    class Compare
    {
        static List<long> hashes = new();
        static List<long> primePows = new();

        static long GetHash(int l, int r)
        {
            return hashes[r + 1] - hashes[l] * primePows[r - l + 1];
        }

        static bool CheckTwoSubs(int a, int b, int c, int d)
        {
            return GetHash(a, b) == GetHash(c, d);
        }

        static void Main()
        {
            var s = Console.ReadLine();
            var m = int.Parse(Console.ReadLine());
            const long PRIME = 1000000000L + 9L;

            hashes.Add(0);
            primePows.Add(1);

            for (int i = 0; i < s.Length; ++i)
            {
                hashes.Add(hashes[i] * PRIME + s[i]);
                primePows.Add(primePows[i] * PRIME);
            }

            for (int i = 0; i < m; ++i)
            {
                var parts = Console.ReadLine().Split();
                var a = int.Parse(parts[0]) - 1;
                var b = int.Parse(parts[1]) - 1;
                var c = int.Parse(parts[2]) - 1;
                var d = int.Parse(parts[3]) - 1;

                Console.WriteLine(CheckTwoSubs(a, b, c, d) ? "Yes" : "No");
            }   
        }
    }
}
