using System;
using System.Text;

namespace Task_A_SumAndXOR
{
    public class SumAndXOR
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string[] listNums = Console.ReadLine().Split(' ');
            var m = int.Parse(Console.ReadLine());
        
            var (prefSum, prefXOR) = GetPrefix(listNums, n);

            var result = new StringBuilder();

            for (int i = 0; i < m; i++)
            {
                string[] lines = Console.ReadLine().Split(' ');
                var operation = int.Parse(lines[0]);
                var left = int.Parse(lines[1]);
                var right = int.Parse(lines[2]);

                if (operation == 1)
                {
                    var sum = GetSum(prefSum, left, right);
                    result.Append(sum + "\n");
                }

                else if (operation == 2)
                {
                    var xor = GetXOR(prefXOR, left, right);
                    result.Append(xor + "\n");
                }   
            }

            Console.WriteLine(result);
        }

        public static Tuple<long[], long[]> GetPrefix(string[] listNums, int n)
        {
            var numbers = new int[n];
            var prefSum = new long[n + 1];
            prefSum[0] = 0;

            var prefXOR = new long[n + 1];
            prefXOR[0] = 0;

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(listNums[i]);
                prefSum[i + 1] = prefSum[i] + numbers[i];
                prefXOR[i + 1] = prefXOR[i] ^ numbers[i];
            }

            return Tuple.Create(prefSum, prefXOR);
        }

        public static long GetSum(long[] prefSum, int left, int right)
        {
            return prefSum[(long)right] - prefSum[(long)left - 1];
        }

        public static long GetXOR(long[] prefXOR, int left, int right)
        {
            return prefXOR[left - 1] ^ prefXOR[right];
        }
    }
}