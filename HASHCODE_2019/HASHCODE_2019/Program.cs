using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HASHCODE_2019
{
    class Program
    {
        static int iteration = 0;
        static string INPUT_PATH = Directory.GetCurrentDirectory() + $"/../../INPUTS/";
        static string OUT_FILE = Directory.GetCurrentDirectory() + $"/../../SOLUTIONS/SOLUTION{iteration}.txt";
        static string OUT_PATH = Directory.GetCurrentDirectory() + $"/../../SOLUTIONS/";
        static int N;
        static Dictionary<string, int> tags;
        static List<Photo> photos;
         
        static void Main(string[] args)
        {
            string[] inputs = Directory.GetFiles(INPUT_PATH);
            string[] outputFiles = new string[] { $"a_{iteration}.txt", $"b_{iteration}.txt", $"c_{iteration}.txt",
                                                  $"d_{iteration}.txt", $"e_{iteration}.txt"};

            for (int i = 0; i < inputs.Length; i++)
            {
                string input = inputs[i];
                string output = outputFiles[i];
                Console.WriteLine($"Reading {input}");

                string[] lines = File.ReadAllLines(input);
                parseInput(lines);
                var solution = StartSolution.GenerateSlideshow(photos);

                File.WriteAllLines(OUT_PATH + output, solution.Print());
            }
            Console.ReadLine();
        }

        static void parseInput(string[] lines) {
            tags = new Dictionary<string, int>();
            photos = new List<Photo>();
            N = int.Parse(lines[0].Split(new char[] { ' ' })[0]);
            for (int i = 0; i < N; i++)
            {
                string line = lines[i + 1];
                string[] words = line.Split(new char[] { ' ' });

                string Orientation = words[0];
                int ntgs = int.Parse(words[1]);
                string[] ts = new string[ntgs];
                int[] ids = new int[ntgs];
                Array.Copy(words, 2, ts, 0, ntgs);
                for (int j = 0; j < ntgs; j++)
                {
                    if (tags.ContainsKey(ts[j]))
                        ids[j] = tags[ts[j]];
                    else
                    {
                        tags.Add(ts[j], tags.Count);
                        ids[j] = tags[ts[j]];
                    }
                        
                }
                photos.Add(new Photo(i, Orientation == "H", ids));

            }

        }
    }
}
