using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip_Code_Frequency_Counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> zipCounts = new Dictionary<string, int>();

            Console.WriteLine("Enter at least 25 zip codes (press Enter after each):");
            int entryCount = 0;

            while (entryCount < 25)
            {
                Console.Write($"Zip {entryCount + 1}: ");
                string zip = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(zip))
                {
                    Console.WriteLine("Zip code cannot be empty. Try again.");
                    continue;
                }

                if (zip.Length != 5 || !zip.All(char.IsDigit))
                {
                    Console.WriteLine("Please enter a valid 5-digit zip code.");
                    continue;
                }

                if (zipCounts.ContainsKey(zip))
                {
                    zipCounts[zip]++;
                }
                else
                {
                    zipCounts[zip] = 1;
                }

                entryCount++;
            }
            var sortedZips = zipCounts
           .OrderByDescending(pair => pair.Value)
           .ThenBy(pair => pair.Key);

            Console.WriteLine("\nZip Code Frequency Report");
            Console.WriteLine("--------------------------");
            Console.WriteLine("| {0,-10} | {1,-8} |", "Zip Code", "Count");
            Console.WriteLine("--------------------------");

            foreach (var entry in sortedZips)
            {
                Console.WriteLine("| {0,-10} | {1,-8} |", entry.Key, entry.Value);
            }
        }
    }
}
