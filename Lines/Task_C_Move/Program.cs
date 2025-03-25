using System;
using System.Collections.Generic;

namespace Task_C_Move
{
    class Move
    {
        const int p = 31;
        const long m = 1000000009;
        static long  pw;

        static void Main()
        {
            var a = Console.ReadLine();
            var b = Console.ReadLine();

            Console.WriteLine(CountCyclicShifts(a, b));
        }

        static int CountCyclicShifts(string a, string b)
        {
            var aLength = a.Length;
            var bLength = b.Length;

            pw = 1;

            for (int i = 0; i < bLength; i++)
            {
                pw = (pw * p) % m;
            }

            var hashesA = CreateHashes(a);
            var hashesB = CreateHashes(b + b);
            var hashes = new HashSet<long>();

            for (int i = 0; i <= bLength; i++)
            {
                hashes.Add(GetHash(i, bLength, hashesB));
            }

            var count = 0;

            for (int i = 0; i <= aLength - bLength; i++)
            {
                if (hashes.Contains(GetHash(i, bLength, hashesA)))
                {
                    count++;
                }
            }
            return count;
        }


        static long GetHash(int start, int delta, long[] hashes)
        {
            var hash = (hashes[start + delta] - hashes[start] * pw) % m;
            return hash < 0 ? hash + m : hash;
        }

        static long[] CreateHashes(string s)
        {
            var hashes = new long[s.Length + 1];
            for (int i = 1; i <= s.Length; i++)
            {
                hashes[i] = (hashes[i - 1] * p + s[i - 1]) % m;
            }
            return hashes;
        }
    }
}