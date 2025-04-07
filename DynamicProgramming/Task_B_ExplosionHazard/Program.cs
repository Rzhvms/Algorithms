using System;
using System.Collections.Generic;

namespace Task_B_ExplosionHazard
{
    class Program
    {
        private static Dictionary<(int, string), long> _memo = new Dictionary<(int, string), long>();

        static long CountSafeStacks(int  remainingContainers, string previousContainerType)
        {
            if (_memo.TryGetValue((remainingContainers, previousContainerType), out var cached))
                return cached;

            if (remainingContainers == 0)
                return 1;

            var count = 0L;
            foreach (var containerType in new[] { "A", "B", "C" })
            {
                if (containerType == "A" && previousContainerType == "A")
                    continue;
                count += CountSafeStacks(remainingContainers - 1, containerType);
            }

            _memo[(remainingContainers, previousContainerType)] = count;
            return count;
        }

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(CountSafeStacks(n, ""));
        }
    }
}