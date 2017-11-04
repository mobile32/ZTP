namespace ClassLibrary.Models
{
    public class Location
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public LocationType Type { get; set; }
        public int BoroughId { get; set; }
        public int TownshipId { get; set; }
        public int VoivodeshipId { get; set; }
    }
}