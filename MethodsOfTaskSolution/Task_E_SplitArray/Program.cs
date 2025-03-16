using System;

namespace Task_E_SplitArray
{
    public class SplitArray
    {
        static void Main()
        {
            var inputValues = Console.ReadLine().Split(' ');
            var n = int.Parse(inputValues[0]);
            var k = int.Parse(inputValues[1]);

            var array = Console.ReadLine().Split(' ');
            var intArray = Array.ConvertAll(array, int.Parse);

            var result = GetValue(n, k, intArray);

            Console.WriteLine(result);
        }

        static long GetValue(int n, int k, int[] intArray)
        {
            long sum = 0;
            long maxValue = 0;

            for (int i = 0; i < n; i++)
            {
                sum += intArray[i];
                if (intArray[i] > maxValue)
                {
                    maxValue = intArray[i];
                }
            }

            long left = maxValue;
            long right = sum;

            while (left <= right)
            {
                long mid = (left + right) / 2;
                long count = 1;
                long currentSum = intArray[0];

                for (int i = 1; i < intArray.Length; i++)
                {
                    if (currentSum + intArray[i] <= mid)
                    {
                        currentSum += intArray[i];
                    }
                    else
                    {
                        currentSum = intArray[i];
                        count++;
                    }
                }

                if (count <= k)
                {
                    right = mid - 1;
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