using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public class GUSData
    {
        public ICollection<Location> Locations { get; set; }
        public ICollection<Borough> Boroughs { get; set; }
        public ICollection<Township> Townships { get; set; }
        public ICollection<Voivodeship> Voivodeships { get; set; }
    }
}