namespace Trust_Your_Locals
{
    public class Pin
    {
        public Pin(string name, string lat, string lng)
        {
            this.name = name;
            this.lat = lat;
            this.lng = lng;
        }

        public string name { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
