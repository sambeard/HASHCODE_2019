using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HASHCODE_2019
{
    class Photo
    {
        public int ID;
        public bool Horizontal;
        public int[] Tags;

        public Photo(int id, bool horizontal, int[] tags)
        {
            ID = id;
            Horizontal = horizontal;
            Tags = tags;
        }
    }
}
