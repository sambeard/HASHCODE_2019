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


        }

        public void iterate() {
            int i = 0;

            while (i++ < MAX_ITERATION) {
                // get action
                ILSAction action = ActionChoser.GetAction();

                // look at diff

                // execute if diff > 0

            }

            // return slideshow

        }

    }
}
