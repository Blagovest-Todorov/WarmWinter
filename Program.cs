using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numHats = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numScarfs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> hats = new Stack<int>(numHats); // lastHat
            Queue<int> scarfs = new Queue<int>(numScarfs); //first Scarf 
            List<int> sets = new List<int>();
        
            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currSetValue = 0;
                int lastHat = hats.Peek();
                int firstScarf = scarfs.Peek();

                if (lastHat > firstScarf)
                {
                    currSetValue = lastHat + firstScarf;
                    sets.Add(currSetValue); // make Set and Remove currHat and currScarf
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (firstScarf > lastHat)
                {
                    hats.Pop();
                    //continue;
                }
                else if (firstScarf == lastHat)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(lastHat + 1);
                }
            }

            if (sets.Count > 0)
            {
                Console.WriteLine($"The most expensive set is: {sets.Max()}");
                Console.WriteLine(String.Join(" ", sets));
            }
            else
            {
                Environment.Exit(1);
            }
        }
    }
}
