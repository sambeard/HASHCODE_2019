using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HASHCODE_2019
{
    public class ScoreEvaluator
    {
        /* static int EvaluateSlideshow(Slideshow slideshow)
         {
             int total_score = 0;
             if (slideshow.Slides.Count >= 2)
             {
                 for (int i = 0; i < slideshow.Slides.Count - 1; i++)
                 {
                     int current_min = Math.Min(CommonTagsScore(slideshow.re, slideshow.Slides[i + 1]), S_1_Ex_Tags(slideshow.Slides[i], slideshow.Slides[i + 1]));
                     total_score += Math.Min(current_min, S_2_Ex_Tags(slideshow.Slides[i], slideshow.Slides[i + 1]));

             }
             return total_score;
         }
         */

        public static int InterestScore(Slide slide_n, Slide slide_n1) {
            if (slide_n == null || slide_n1 == null) { return 0;}
            int a, b, c;
            a = CommonTagsScore(slide_n, slide_n1);
            b = S_1_Ex_Tags(slide_n, slide_n1);
            c = S_2_Ex_Tags(slide_n, slide_n1);
                       
            int d = Math.Min(a, b);
            return Math.Min(d, c);
        }
        static int CommonTagsScore(Slide slide_n, Slide slide_n1)
        {
            List<int> slides = (List<int>)slide_n.GetTags().Intersect(slide_n1.GetTags());
            return slides.Count;
        }

        static int S_1_Ex_Tags(Slide slide_n, Slide slide_n1)
        {

            List<int> slides = (List<int>)slide_n.GetTags().Union(slide_n1.GetTags());
            List<int> left_slides = slide_n.GetTags().Where(x => (!slides.Contains(x))).ToList();
            return left_slides.Count;
        }

        static int S_2_Ex_Tags(Slide slide_n, Slide slide_n1)
        {
            List<int> slides = (List<int>)slide_n.GetTags().Union(slide_n1.GetTags());
            List<int> right_slides = slide_n1.GetTags().Where(x => (!slides.Contains(x))).ToList();
            return right_slides.Count;
        }
    }
}
