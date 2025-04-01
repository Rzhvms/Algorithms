using System;
using System.Collections.Generic;

namespace Task_E_NumbersTheory
{
    class Program
    {
        static int MinDigitSum(int K)
        {
            var visited = new int[K];
            Array.Fill(visited, int.MaxValue);
            visited[1] = 1;
            var queue = new Queue<int>();
            queue.Enqueue(1);

            while (queue.Count > 0)
            {
                var currNum = queue.Dequeue();
                var currSum = visited[currNum];

                for (var digit = 0; digit < 10; digit++)
                {
                    var nextNum = (currNum * 10 + digit) % K;
                    var nextSum = currSum + digit;

                    if (nextSum < visited[nextNum])
                    {
                        visited[nextNum] = nextSum;
                        queue.Enqueue(nextNum);
                    }
                }
            }   

            return visited[0];
        }

        static void Main()
        {
            var K = int.Parse(Console.ReadLine());
            Console.WriteLine(MinDigitSum(K));
        }
    }
}