using System;
using System.Collections.Generic;
using System.Linq;

namespace entropy
{
    public class Consecutive
    {
        List<int> num1 = new List<int>() { 1, 2, 3, 4 };
        List<int> num2 = new List<int>() { 1, 2, 6, 7 };
        List<int> num3 = new List<int>() { 1, 3, 5, 7 };

        public void UseDistinct()
        {
            Console.WriteLine("UseDistinct");
            // True
            Console.WriteLine($"{!num1.Select((i, j) => i - j).Distinct().Skip(1).Any()}");
            // False
            Console.WriteLine($"{!num2.Select((i, j) => i - j).Distinct().Skip(1).Any()}");
            // False
            Console.WriteLine($"{!num3.Select((i, j) => i - j).Distinct().Skip(1).Any()}");
        }

        public void UseZip()
        {
            Console.WriteLine("UseZip");
            // True
            Console.WriteLine($"{num1.Zip(num1.Skip(1), (l, r) => l + 1 == r).All(t => t)}");
            // False
            Console.WriteLine($"{num2.Zip(num2.Skip(1), (l, r) => l + 1 == r).All(t => t)}");
            // False
            Console.WriteLine($"{num3.Zip(num3.Skip(1), (l, r) => l + 1 == r).All(t => t)}");
        }

        public void HasPartUseZip()
        {
            Console.WriteLine("HasPartUseZip");
            // True
            Console.WriteLine($"{num1.Zip(num1.Skip(1), (l, r) => l + 1 == r).Any(t => t)}");
            // True
            Console.WriteLine($"{num2.Zip(num2.Skip(1), (l, r) => l + 1 == r).Any(t => t)}");
            // False
            Console.WriteLine($"{num3.Zip(num3.Skip(1), (l, r) => l + 1 == r).Any(t => t)}");
        }
    }
}
