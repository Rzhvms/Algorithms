using System;
using System.Collections.Generic;

namespace Task_E_InexactMatch
{
    class Program
    {
        static void Main()
        {
            var p = Console.ReadLine();
            var t = Console.ReadLine();

            var result = new List<int>();
            var pLength = p.Length;
            var tLength = t.Length;

            for (int i = 0; i < tLength - pLength + 1; i++)
            {
                var count = 0;
                for (int j = 0; j < pLength; j++)
                {
                    if (t[i + j] != p[j])
                    {
                        count += 1;
                        if (count > 1)
                        {
                            break;
                        }
                    }
                }

                if (count <= 1)
                {
                    result.Add(i + 1);
                }
            }

            Console.WriteLine(result.Count);
            foreach (int i in result)
            {
                Console.Write(" " + i);
            }
        }
    }
}