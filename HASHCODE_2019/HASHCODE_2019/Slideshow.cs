using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASHCODE_2019
{
    class Slideshow
    {
        public LinkedList<Slide> Slides;
        public Dictionary<Slide, LinkedListNode<Slide>> References;

        public Slideshow(List<Slide> slides)
        {
            Slides = new LinkedList<Slide>();
            References = new Dictionary<Slide, LinkedListNode<Slide>>();

            foreach (var slide in slides)
            {
                var node = Slides.AddLast(slide);
                References.Add(slide, node);
            }
        }
        public void RemoveSlide(Slide s) {
            Slides.Remove(s);
            References.Remove(s);
        }
        public void AddSlideBefore(LinkedListNode<Slide> before, Slide s) {
            var node = Slides.AddBefore(before, s);
            References.Add(s,node);
        }

        public void Print()
        {
            Console.WriteLine(Slides.Count);
            foreach (var slide in Slides)
            {
                slide.Print();
            }
        }

        public Slide GetRandomslide() {
            Random rand = new Random();
           return References.ElementAt(rand.Next(0, References.Count)).Key;
        }
    }

    abstract class Slide
    {
        public abstract void Print();

        public abstract List<int> GetTags();
    }

    class HorizontalSlide : Slide
    {
        public Photo Photo;

        public HorizontalSlide(Photo photo)
        {
            Photo = photo;
        }

        public override void Print()
        {
            Console.WriteLine(Photo.ID);
        }

        public override List<int> GetTags() {
            return Photo.Tags.ToList();

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

        public override void Print()
        {
            Console.WriteLine($"{Photo1.ID} {Photo2.ID}");
        }

        public override List<int> GetTags()
        {

            List<int> tags = Photo1.Tags.ToList();
            tags.AddRange(Photo2.Tags.ToList());
            return tags;

        }
    }
}
