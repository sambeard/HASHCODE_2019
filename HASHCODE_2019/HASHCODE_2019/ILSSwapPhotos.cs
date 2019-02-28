using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASHCODE_2019
{
    class ILSSwapPhotos : ILSAction
    {
        VerticalSlide FirstSlide;
        VerticalSlide SecondSlide;
        VerticalSlide newSlide1;
        VerticalSlide newSlide2;
        LinkedListNode<Slide> FirstSlideNode;
        LinkedListNode<Slide> SecondSlideNode;


        public ActionObject Calculate(LocalSearch localSearch)
        {
            // get slides
            var s = localSearch.SlideShow.GetRandomslide();
            if (s is VerticalSlide) FirstSlide = s as VerticalSlide;
            else return ActionObject.FailedObject();
            s = localSearch.SlideShow.GetRandomslide();
            if (s is VerticalSlide) SecondSlide = s as VerticalSlide;
            else return ActionObject.FailedObject();

            if (FirstSlide == SecondSlide)
                return ActionObject.FailedObject();

            FirstSlideNode = localSearch.SlideShow.References[FirstSlide];
            SecondSlideNode = localSearch.SlideShow.References[SecondSlide];

            if (FirstSlideNode.Next == SecondSlideNode.Previous)
            {
                // special case
                return ActionObject.FailedObject();
            }
            if (FirstSlideNode.Previous == SecondSlideNode.Next)
            {
                // special case
                return ActionObject.FailedObject();
            }

            newSlide1 = new VerticalSlide(FirstSlide.Photo1, SecondSlide.Photo1);
            newSlide2 = new VerticalSlide(FirstSlide.Photo2, SecondSlide.Photo2);

            int diff = 0;

            // interest of original
            diff -= ScoreEvaluator.InterestScore(FirstSlideNode.Previous?.Value, FirstSlide) + ScoreEvaluator.InterestScore(FirstSlide, FirstSlideNode.Next?.Value);
            diff -= ScoreEvaluator.InterestScore(SecondSlideNode.Previous?.Value, SecondSlide) + ScoreEvaluator.InterestScore(SecondSlide, SecondSlideNode.Next?.Value);


            // interest of new
            diff += ScoreEvaluator.InterestScore(FirstSlideNode.Previous?.Value, newSlide1) + ScoreEvaluator.InterestScore(newSlide1, FirstSlideNode.Next?.Value);
            diff += ScoreEvaluator.InterestScore(SecondSlideNode.Previous?.Value, newSlide2) + ScoreEvaluator.InterestScore(newSlide2, SecondSlideNode.Next?.Value);

            return new ActionObject(diff);
        }

        public void Execute(LocalSearch localSearch)
        {
            var list = localSearch.SlideShow.Slides;

            var temp1 = FirstSlideNode.Previous;
            var temp2 = SecondSlideNode.Previous;

            // add first slide
            LinkedListNode<Slide> node1;
            if (temp1 == null)
                node1 = list.AddFirst(newSlide1);
            else
                node1 = list.AddAfter(temp1, newSlide1);
            localSearch.SlideShow.References[newSlide1] = node1;

            // add second slide
            LinkedListNode<Slide> node2;
            if (temp2 == null)
                node2 = list.AddFirst(newSlide2);
            else
                node2 = list.AddAfter(temp2, newSlide2);
            localSearch.SlideShow.References[newSlide2] = node2;

            list.Remove(FirstSlideNode);
            list.Remove(SecondSlideNode);
        }
    }
}
