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


    class ScoreEvaluator
    {
        static int EvaluateSlideshow(List<Object> slideshow) {
            int total_score = 0;
            if (slideshow.Count >= 2)
            {
                for (int i = 0; i < slideshow.Count-1; i++)
                {
                    int current_min = Math.Min(CommonTagsScore(slideshow[i],slideshow[i+1]), S_1_Ex_Tags(slideshow[i], slideshow[i + 1]));
                    total_score += Math.Min(current_min, S_2_Ex_Tags(slideshow[i], slideshow[i + 1]));
                }
            }
            return total_score; }

        static int CommonTagsScore(Object slide_n, Object slide_n1) { 
        
        return 0; }

        static int S_1_Ex_Tags(Object slide_n, Object slide_n1) { 
        
        return 0; }

        static int S_2_Ex_Tags(Object slide_n, Object slide_n1) { 
        
        return 0; }
    }
}
