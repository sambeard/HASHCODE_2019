using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASHCODE_2019
{
    class Program
    {
        static int iteration = 0;
        static string INPUT_FILE = System.IO.Directory.GetCurrentDirectory() + "/../../INPUT_FILE.txt";
        static string OUT_FILE = System.IO.Directory.GetCurrentDirectory() + $"/../../SOLUTIONS/SOLUTION{iteration}.txt";
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(INPUT_FILE);
            foreach (var line  in lines)
            {
                Console.WriteLine(line);
            }
            System.IO.File.WriteAllLines(OUT_FILE, lines);
            Console.ReadLine();

        }
    }
}
