using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASHCODE_2019
{
    class ILSSwapAction : ILSAction
    {
        Slide FirstSlide;
        Slide SecondSlide;
        LinkedListNode<Slide> FirstSlideNode;
        LinkedListNode<Slide> SecondSlideNode;


        public ActionObject Calculate(LocalSearch localSearch)
        {
            // get slides
            FirstSlide = localSearch.SlideShow.GetRandomslide();
            SecondSlide = localSearch.SlideShow.GetRandomslide();
            if (FirstSlide == SecondSlide)
                return ActionObject.FailedObject();

            FirstSlideNode = localSearch.SlideShow.References[FirstSlide];
            SecondSlideNode = localSearch.SlideShow.References[SecondSlide];

            if (FirstSlideNode.Next == SecondSlideNode.Previous) {
                // special case
                return ActionObject.FailedObject();
            }
            if (FirstSlideNode.Previous == SecondSlideNode.Next) {
                // special case
                return ActionObject.FailedObject();
            }

            int diff = 0;

            // interest of original
            diff -= ScoreEvaluator.InterestScore(FirstSlideNode.Previous?.Value, FirstSlide) + ScoreEvaluator.InterestScore(FirstSlide, FirstSlideNode.Next?.Value);
            diff -= ScoreEvaluator.InterestScore(SecondSlideNode.Previous?.Value, SecondSlide) + ScoreEvaluator.InterestScore(SecondSlide, SecondSlideNode.Next?.Value);


            // interest of new
            diff += ScoreEvaluator.InterestScore(FirstSlideNode.Previous?.Value, SecondSlide) + ScoreEvaluator.InterestScore(SecondSlide, FirstSlideNode.Next?.Value);
            diff += ScoreEvaluator.InterestScore(SecondSlideNode.Previous?.Value, FirstSlide) + ScoreEvaluator.InterestScore(FirstSlide, SecondSlideNode.Next?.Value);

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
                node1 = list.AddFirst(SecondSlide);
            else
                node1 = list.AddAfter(temp1, SecondSlide);
            localSearch.SlideShow.References[SecondSlide] = node1;

            // add second slide
            LinkedListNode<Slide> node2;
            if (temp2 == null)
                node2 =list.AddFirst(FirstSlide);
            else
                node2 =list.AddAfter(temp2, FirstSlide);
            localSearch.SlideShow.References[FirstSlide] = node2;

            list.Remove(FirstSlideNode);
            list.Remove(SecondSlideNode);



        }
    }
}
