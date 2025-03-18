using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_G_TicketWindows
{
    class TicketWindows
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var events = new List<(int time, int type)>();
            int allWindows = n;
            int curWindows = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var nums = Array.ConvertAll(input, int.Parse);

                int startTime = ConvertToSeconds(nums[0], nums[1], nums[2]);
                int endTime = ConvertToSeconds(nums[3], nums[4], nums[5]);

                if (startTime == endTime)
                {
                    allWindows--;
                }
                else
                {
                    events.Add((startTime, 1));
                    events.Add((endTime, -1));
                    if (startTime > endTime)
                    {
                        curWindows++;
                    }
                }
            }

            events.Sort();
            int result = CalculateTotalTime(events, curWindows, allWindows);

            Console.WriteLine(result);
        }

        static int ConvertToSeconds(int hours, int minutes, int seconds)
        {
            return hours * 3600 + minutes * 60 + seconds;
        }

        static int CalculateTotalTime(List<(int time, int type)> events, int curWindows, int allWindows)
        {
            int result = 0;

            if (curWindows == allWindows)
            {
                result += events[0].time;
            }

            for (int i = 0; i < events.Count; i++)
            {
                curWindows += events[i].type;

                if (curWindows == allWindows)
                {
                    if (i != events.Count - 1)
                    {
                        result += events[i + 1].time - events[i].time;
                    }
                    else
                    {
                        result += 24 * 3600 - events[i].time;
                    }
                }
            }

            return result;
        }
    }
}