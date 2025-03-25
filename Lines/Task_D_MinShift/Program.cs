using System;
using System.Collections.Generic;

namespace Task_D_MinShift
{
    class Program
    {
        static void Main()
        {
            var str = Console.ReadLine();
            Console.WriteLine(FindMinShift(str));
        }

        static string FindMinShift(string str)
        {
            int n = str.Length;
            if (n == 0) return str;
        
            string doubled = str + str;
            int minIndex = 0;
        
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (doubled[minIndex + j] < doubled[i + j])
                    {
                        break;
                    }   
                    if (doubled[minIndex + j] > doubled[i + j])
                    {
                        minIndex = i;
                        break;
                    }
                }
            }
        
            return str.Substring(minIndex) + str.Substring(0, minIndex);
        }
    }
}