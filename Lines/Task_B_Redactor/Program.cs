using System;
using System.Collections.Generic;

namespace Task_B_Redactor
{
    class Redactor
    {
        static void Main()
        {
            var T = Console.ReadLine();
            var q = int.Parse(Console.ReadLine());

            for (int i = 0; i < q; i++)
            {
                var str = Console.ReadLine();
                var result = Kmp(T, str);
                Console.Write(result.Count);

                foreach (int elem in result)
                {
                    Console.Write(" " + elem);
                }
                Console.WriteLine();
            }
        }

        static int[] ZFunction(string str)
        {
            var prefixFunc = new int[str.Length];
            var border = 0;

            for (int i = 1; i < str.Length; i++)
            {
                while (border > 0 && str[i] != str[border])
                {
                    border = prefixFunc[border - 1];
                }
                if (str[i] == str[border])
                {
                    border++;
                }
                else
                {
                    border = 0;
                }
                prefixFunc[i] = border;
            }
            return prefixFunc;
        }

        static List<int> Kmp(string T, string str)
        {
            var prefixFunc = ZFunction(str);
            var indexResult = new List<int>();
            var border = 0;

            for (int i = 0; i < T.Length; i++)
            {
                while (border > 0 && T[i] != str[border])
                {
                    border = prefixFunc[border - 1];
                }
                if (T[i] == str[border])
                {
                    border++;
                }
                else 
                {
                    border = 0;
                }

                if (border == str.Length)
                {
                    indexResult.Add(i - str.Length + 1);
                    border = prefixFunc[border - 1];
                }
            }
            return indexResult;
        }
    }
}