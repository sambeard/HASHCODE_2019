using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASHCODE_2019
{
    static class StartSolution
    {
        public static Slideshow GenerateSlideshow(List<Photo> photos)
        {
            List<Slide> slides = new List<Slide>();
            List<Photo> horizontal = photos.Where(p => p.Horizontal).ToList();
            List<Photo> vertical = photos.Where(p => !p.Horizontal).ToList();

            int verticalCount = 0;
            for (int i = 0; i < horizontal.Count; i++)
            {
                Photo p = horizontal[i];
                slides.Add(new HorizontalSlide(p));

                if(verticalCount+1 < vertical.Count)
                {
                    Photo p1, p2;
                    p1 = vertical[verticalCount++];
                    p2 = vertical[verticalCount++];
                    slides.Add(new VerticalSlide(p1, p2));
                }
            }
            while(verticalCount + 1 < vertical.Count)
            {
                Photo p1, p2;
                p1 = vertical[verticalCount++];
                p2 = vertical[verticalCount++];
                slides.Add(new VerticalSlide(p1, p2));
            }

            return new Slideshow(slides);
        }
    }
}
