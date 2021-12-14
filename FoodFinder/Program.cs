using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var pears = new List<char>(); //"pear"
            var flours = new List<char>(); //"flour"
            var porks = new List<char>(); //"pork"
            var olives = new List<char>(); //"olive"
            var vowels = new Queue<char>(Console.ReadLine().Split(" ").Select(char.Parse));
            var consonants = new Stack<char>(Console.ReadLine().Split(" ").Select(char.Parse));
            while (consonants.Count > 0)
            {
                if ("pear".Contains(vowels.Peek()) || "pear".Contains(consonants.Peek()))
                {
                    if ("pear".Contains(vowels.Peek()))
                    {
                        if (!pears.Contains(vowels.Peek()))
                        {
                            pears.Add(vowels.Peek());
                        }
                    }
                    if ("pear".Contains(consonants.Peek()))
                    {
                        if (!pears.Contains(consonants.Peek()))
                        {
                            pears.Add(consonants.Peek());
                        }
                    }
                }

                if ("flour".Contains(vowels.Peek()) || "flour".Contains(consonants.Peek()))
                {
                    if ("flour".Contains(vowels.Peek()))
                    {
                        if (!flours.Contains(vowels.Peek()))
                        {
                            flours.Add(vowels.Peek());
                        }
                    }
                    if ("flour".Contains(consonants.Peek()))
                    {
                        if (!flours.Contains(consonants.Peek()))
                        {
                            flours.Add(consonants.Peek());
                        }
                    }
                }
                if ("pork".Contains(vowels.Peek()) || "pork".Contains(consonants.Peek()))
                {
                    if ("pork".Contains(vowels.Peek()))
                    {
                        if (!porks.Contains(vowels.Peek()))
                        {
                            porks.Add(vowels.Peek());
                        }
                    }
                    if ("pork".Contains(consonants.Peek()))
                    {
                        if (!porks.Contains(consonants.Peek()))
                        {
                            porks.Add(consonants.Peek());
                        }
                    }
                }
                if ("olive".Contains(vowels.Peek()) || "olive".Contains(consonants.Peek()))
                {
                    if ("olive".Contains(vowels.Peek()))
                    {
                        if (!olives.Contains(vowels.Peek()))
                        {
                            olives.Add(vowels.Peek());
                        }
                    }
                    if ("olive".Contains(consonants.Peek()))
                    {
                        if (!olives.Contains(consonants.Peek()))
                        {
                            olives.Add(consonants.Peek());
                        }
                    }
                }
                consonants.Pop();
                vowels.Enqueue(vowels.Dequeue());
            }
            int countOfWords = 0;
            bool isPear = false;
            bool isFlour = false;
            bool isPork = false;
            bool isOlive = false;
            if (pears.Count >= 4)
            {
                isPear = true;
                countOfWords++;
            }
            if (flours.Count >= 5)
            {
                isFlour = true;
                countOfWords++;
            }
            if (porks.Count >= 4)
            {
                isPork = true;
                countOfWords++;
            }
            if (olives.Count >= 5)
            {
                isOlive = true;
                countOfWords++;
            }
            Console.WriteLine($"Words found: {countOfWords}");
            if (isPear)
            {
                Console.WriteLine("pear");
            }
            if (isFlour)
            {
                Console.WriteLine("flour");
            }
            if (isPork)
            {
                Console.WriteLine("pork");
            }
            if (isOlive)
            {
                Console.WriteLine("olive");
            }
        }
    }
}
