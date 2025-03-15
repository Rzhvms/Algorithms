using System;
using System.Text;

namespace Task_B_2dSum
{
    public class DoubleDSums
    {
        public static void Main(string[] args)
        {
            var matrixValues = Console.ReadLine().Split(' ');
            var n = int.Parse(matrixValues[0]);
            var m = int.Parse(matrixValues[1]);
            var k = int.Parse(matrixValues[2]);

            var prefSum = MakePrefixArray(n, m);
            var result = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                string[] rows = Console.ReadLine().Split(' ');

                var currentSum = 0;
                prefSum[i] = new long[m + 1];
                prefSum[i][0] = 0;
                for (int j = 1; j <= m; j++)
                {
                    var row = int.Parse(rows[j - 1]);
                    currentSum += row;
                    prefSum[i][j] = prefSum[i - 1][j] + currentSum;
                }
            }

            for (int i = 0; i < k; i++)
            {
                string[] kValues = Console.ReadLine().Split(' ');

                var y1 = int.Parse(kValues[0]);
                var x1 = int.Parse(kValues[1]);
                var y2 = int.Parse(kValues[2]);
                var x2 = int.Parse(kValues[3]);

                var resultSum = prefSum[y2][x2] 
                                - prefSum[y2][x1 - 1] 
                                - prefSum[y1 - 1][x2] 
                                + prefSum[y1 - 1][x1 - 1];
                
                result.Append(resultSum + "\n");
            }

            Console.WriteLine(result);
        }

        public static long[][] MakePrefixArray(int n, int m)
        {
            var prefSum = new long[n + 1][];
            prefSum[0] = new long[m + 1];

            for (int i = 0; i < m; i++)
            {
                prefSum[0][i] = 0;
            }

            return prefSum;
        }
    }
}