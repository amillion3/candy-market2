using System;

namespace candy_market2
{
    public class Candy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CandyType { get; set; }
        public string Manufacturer { get; set; }
        public string FlavorCategory { get; set; }
        public DateTime DateReceived { get; set; }
    }
}