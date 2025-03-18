using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_F_DrawLine
{
    class Task_F_DrawLine
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            List<(int time, int type)> array = new List<(int, int)>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var left = int.Parse(input[0]);
                var right = int.Parse(input[1]);

                array.Add((left, 1));
                array.Add((right, -1));
            }

            array.Sort();

            var counter = 1;
            var result = 0;

            for (int i = 1; i < array.Count; i++)
            {
                if (counter != 0)
                {
                    result += (array[i].time - array[i-1].time);
                }
                counter += array[i].type;
            }
            

            Console.WriteLine(result);
        }
    }
}