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
        static string INPUT_FILE = System.IO.Directory.GetCurrentDirectory() + $"/../../INPUTS/a_example.txt";
        static string OUT_FILE = System.IO.Directory.GetCurrentDirectory() + $"/../../SOLUTIONS/SOLUTION{iteration}.txt";
        static int N;
        static List<string> tags;
        static List<string> photos;

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(INPUT_FILE);

            parseInput(lines);
            System.IO.File.WriteAllLines(OUT_FILE, lines);
            Console.ReadLine();

        }

        static void parseInput(string[] lines) {
            tags = new List<string>();
            N = int.Parse(lines[0].Split(new char[] { ' ' })[0]);
            for (int i = 0; i < N; i++)
            {
                string line = lines[i + 1];
                string[] words = line.Split(new char[] { ' ' });

                string Orientation = words[0];
                int ntgs = int.Parse(words[1]);
                string[] ts = new string[ntgs];
                Array.Copy(words, 2, ts, 0, ntgs);
                tags.AddRange(ts);

            }

        }
    }
}
