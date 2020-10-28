using System.Collections.Generic;

namespace Trust_Your_Locals
{
    class Farmer
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public override string ToString()
        {
            return string.Format("Rating: {0} ★ \n\t Comment: {1}", Rating, Comment);
        }

    }
}