namespace ClassLibrary.Models
{
    public class Borough
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdditionalName { get; set; }
        public int TownshipId { get; set; }
        public int VoivodeshipId { get; set; }
    }
}