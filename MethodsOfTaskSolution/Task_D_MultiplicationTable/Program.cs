using System;

namespace Task_D_MultiplicationTable
{
    class MultiplicationTable
    {
        public static void Main()
        {
            var inputValues = Console.ReadLine().Split(' ');
            var n = long.Parse(inputValues[0]);
            var k = long.Parse(inputValues[1]);

            var binSearchValue = BinarySearch(n, k);
            Console.WriteLine(binSearchValue);
        }

        public static long BinarySearch(long n, long k)
        {
            long left = 1; 
            long right = n * n;
            long mid;

            while (left < right)
            {
                long count = 0;
                mid = (left + right) / 2;

                for (int i = 1; i <= n; i++)
                {
                    count += Math.Min(mid / i, n);
                }
                if (count >= k)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }
    }
}
