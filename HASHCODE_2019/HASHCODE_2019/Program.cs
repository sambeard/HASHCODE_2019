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
        static string input = System.IO.Directory.GetCurrentDirectory() + $"/../../INPUTS/a_example.txt";
        static string OUT_FILE = System.IO.Directory.GetCurrentDirectory() + $"/../../SOLUTIONS/SOLUTION{iteration}.txt";
        static List<string[]> inputs;
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(input);


            System.IO.File.WriteAllLines(OUT_FILE, lines);
            Console.ReadLine();

        }
    }
}
