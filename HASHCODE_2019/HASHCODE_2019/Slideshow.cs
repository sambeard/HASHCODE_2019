using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASHCODE_2019
{
    class Slideshow
    {
        public List<Slide> Slides;

        public Slideshow(List<Slide> slides)
        {
            Slides = slides;
        }

        public string[] Print()
        {
            string[] output = new string[Slides.Count + 1];
            output[0] = Slides.Count.ToString();
            for (int i = 0; i < Slides.Count; i++)
            {
                output[i] = Slides[i].Print();
            }
            return output;
        }
    }

    abstract class Slide
    {
        public abstract string Print();
    }

    class HorizontalSlide : Slide
    {
        public Photo Photo;

        public HorizontalSlide(Photo photo)
        {
            Photo = photo;
        }

        public override string Print()
        {
            return Photo.ID.ToString();
        }
    }

    class VerticalSlide : Slide
    {
        public Photo Photo1;
        public Photo Photo2;

        public VerticalSlide(Photo photo1, Photo photo2)
        {
            Photo1 = photo1;
            Photo2 = photo2;
        }

        public override string Print()
        {
            return $"{Photo1.ID} {Photo2.ID}";
        }
    }
}
