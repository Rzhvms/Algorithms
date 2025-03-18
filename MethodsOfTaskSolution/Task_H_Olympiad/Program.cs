using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_H_Olympiad
{
    class Olympiad
    {
        static void Main()
        {
            var firstLine = Console.ReadLine().Split();
            var n = long.Parse(firstLine[0]);
            var c = long.Parse(firstLine[1]);

            var tasks = new List<(long startTime, long duration)>();
            for (long i = 0; i < n; i++)
            {
                var taskInput = Console.ReadLine().Split();
                long startTime = long.Parse(taskInput[0]);
                long duration = long.Parse(taskInput[1]);
                tasks.Add((startTime, duration));
            }

            var result = SolveTasks(n, c, tasks);

            Console.WriteLine(result.totalScore);
            Console.WriteLine(result.numSolved);
            Console.WriteLine(string.Join(" ", result.solvedTasks));
        }

        static (long totalScore, long numSolved, List<string> solvedTasks) SolveTasks(long n, long c, List<(long startTime, long duration)> tasks)
        {
            long totalScore = 0;
            var solvedTasks = new List<string>();
            var pq = new PriorityQueue<(long endTime, long taskIndex), long>();

            for (long taskIndex = 0; taskIndex < tasks.Count; taskIndex++)
            {
                var task = tasks[(int)taskIndex];
                long endTime = task.startTime + task.duration;
                pq.Enqueue((endTime, taskIndex), endTime);
            }

            long currentTime = 0;

            while (pq.Count > 0)
            {
                var (endTime, taskIndex) = pq.Dequeue();
                var task = tasks[(int)taskIndex];

                if (task.startTime >= currentTime)
                {
                    currentTime = task.startTime + task.duration;
                    totalScore += c;
                    solvedTasks.Add((taskIndex + 1).ToString());
                }
            }

            return (totalScore, solvedTasks.Count, solvedTasks);
        }
    }

    public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        private readonly List<(TElement element, TPriority priority)> _heap = new List<(TElement, TPriority)>();

        public int Count => _heap.Count;

        public void Enqueue(TElement element, TPriority priority)
        {
            _heap.Add((element, priority));
            int index = _heap.Count - 1;
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (_heap[parentIndex].priority.CompareTo(_heap[index].priority) <= 0)
                    break;

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        public TElement Dequeue()
        {
            if (_heap.Count == 0)
                throw new InvalidOperationException();

            var result = _heap[0].element;
            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);

            int index = 0;
            while (true)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;

                if (leftChildIndex >= _heap.Count)
                    break;

                int smallestChildIndex = leftChildIndex;
                if (rightChildIndex < _heap.Count && _heap[rightChildIndex].priority.CompareTo(_heap[leftChildIndex].priority) < 0)
                    smallestChildIndex = rightChildIndex;

                if (_heap[index].priority.CompareTo(_heap[smallestChildIndex].priority) <= 0)
                    break;

                Swap(index, smallestChildIndex);
                index = smallestChildIndex;
            }

            return result;
        }

        private void Swap(int i, int j)
        {
            var temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }
    }
}