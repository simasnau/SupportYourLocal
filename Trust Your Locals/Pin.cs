using System;

namespace Trust_Your_Locals
{
    public struct Pin
    {
        public string Name;
        private string lat;
        private string lng;

        public string Lat
        {
            get
            {
                return lat;
            }
            set
            {
                if (Double.Parse(value.Substring(0, 5)) <= 90 && Double.Parse(value.Substring(0, 5)) >= -90) lat = value;
                else lat = "0";
            }
        }

        public string Lng
        {
            get
            {
                return lng;
            }
            set
            {
                if (Double.Parse(value.Substring(0, 5)) <= 180 && Double.Parse(value.Substring(0, 5)) >= -180) lng = value;
                else lng = "0";
            }
        }

    }
}