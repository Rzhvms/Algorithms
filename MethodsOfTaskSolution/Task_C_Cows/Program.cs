using System;

namespace CowsTask
{
    public class Cows
    {
        public static void Main(string[] args)
        {
            var inputValues = Console.ReadLine().Split(' ');
            var n = int.Parse(inputValues[0]);
            var k = int.Parse(inputValues[1]);

            var coordinates = Console.ReadLine().Split(' ');
            var coordinatesInt = Array.ConvertAll(coordinates, int.Parse);

            var binSearchValue = BinarySearch(k, coordinatesInt);

            Console.WriteLine(binSearchValue);

        }

        public static int BinarySearch(int k, int[] coordinatesInt)
        {
            var left = 0; 
            var right = coordinatesInt[coordinatesInt.Length - 1];
            var mid = 0;

            while (right - 1 > left)
            {
                var kValue = k;
                mid = (left + right) / 2;

                var lastValue = coordinatesInt[0];
                kValue--;

                for (int i = 0; i < coordinatesInt.Length; i++)
                {
                    if (coordinatesInt[i] - lastValue >= mid)
                    {
                        lastValue = coordinatesInt[i];
                        kValue--;
                    }
                }
                if (kValue > 0)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }

            return left;
        }
    }
}