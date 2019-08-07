using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Engine
    {
        public void Run()
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] safes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long money = 0;

            for (int i = 0; i < safes.Length; i += 2)
            {
                string safeName = safes[i];
                long safeNumber = long.Parse(safes[i + 1]);

                string Inside = WhatIsInside(safeName);

                if (IsEmptyString(Inside))
                {
                    continue;
                }
                else if (IsFullBag(capacity, bag, safeNumber))
                {
                    continue;
                }

                switch (Inside)
                {
                    case "Gem":
                        if (!bag.ContainsKey(Inside))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (safeNumber > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (Rule(bag, safeNumber, Inside,"Gold"))
                        {
                            continue;
                        }
                        break;

                    case "Cash":
                        if (!bag.ContainsKey(Inside))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (safeNumber > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (Rule(bag, safeNumber, Inside, "Gem"))
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(Inside))
                {
                    bag[Inside] = new Dictionary<string, long>();
                }

                if (!bag[Inside].ContainsKey(safeName))
                {
                    bag[Inside][safeName] = 0;
                }
                 
                bag[Inside][safeName] += safeNumber;

                ToIncrease(ref gold, ref gems, ref money, safeNumber, Inside);
            }

            PrintBag(bag);
        }

        private static bool Rule(Dictionary<string, Dictionary<string, long>> bag, long safeNumber, string Inside,string element)
        {
            return bag[Inside].Values.Sum() + safeNumber > bag[element].Values.Sum();
        }

        private static bool IsFullBag(long capacity, Dictionary<string, Dictionary<string, long>> bag, long safeNumber)
        {
            return capacity < bag.Values.Select(x => x.Values.Sum()).Sum() + safeNumber;
        }

        private static void ToIncrease(ref long gold, ref long gems, ref long money, long safeNumber, string Inside)
        {
            if (Inside == "Gold")
            {
                gold += safeNumber;
            }
            else if (Inside == "Gem")
            {
                gems += safeNumber;
            }
            else if (Inside == "Cash")
            {
                money += safeNumber;
            }
        }

        private static void PrintBag(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
                foreach (var item2 in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static bool IsEmptyString(string Inside)
        {
            return Inside == "";
        }

        private static string WhatIsInside(string currentSafeName)
        {
            string result = string.Empty;

            if (currentSafeName.Length == 3)
            {
                result = "Cash";
            }
            else if (currentSafeName.ToLower().EndsWith("gem"))
            {
                result = "Gem";
            }
            else if (currentSafeName.ToLower() == "gold")
            {
                result = "Gold";
            }
            else result = "";

            return result;
        }

    }
}
