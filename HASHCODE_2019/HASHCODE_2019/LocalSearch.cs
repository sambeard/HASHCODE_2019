using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASHCODE_2019
{
    class LocalSearch
    {
        public Slideshow SlideShow;
        public List<Photo> OpenPhotos;
        public List<Photo> ClosedPhotos;
        public ILSActionChooser ActionChoser;

        int MAX_ITERATION = 100000;

        public LocalSearch(List<Photo> photos) {

            OpenPhotos = photos;
            ActionChoser = new ILSActionChooser();
            ClosedPhotos = new List<Photo>();

            // call startsolution
            iterate();

        }

        public void iterate() {
            int i = 0;

            while (i++ < MAX_ITERATION) {
                // get action
                ILSAction action = ActionChoser.GetAction();

                ActionObject a = action.Calculate(this);
                if (!a.FAILED && a.Diff > -2) {

                }

                // execute if diff > 0
                action.Execute(this);

            }
        }

    }
}
