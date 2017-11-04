using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public class TERCData
    {
        public IEnumerable<Voivodeship> Voivodeships { get; set; }
        public IEnumerable<Township> Townships { get; set; }
        public IEnumerable<Borough> Boroughs { get; set; }
    }
}