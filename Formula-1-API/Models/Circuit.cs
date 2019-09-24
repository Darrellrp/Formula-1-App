using System;
namespace Formula_1_API.Models
{
    public class Circuit
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        //public string Alt { get; set; }
        public string Url { get; set; }

        public Circuit()
        {
        }
    }
}
