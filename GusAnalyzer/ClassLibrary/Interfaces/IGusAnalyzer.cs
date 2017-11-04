using System.Collections;
using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Interfaces
{
    public interface IGusAnalyzer
    {
        GUSData GetData(string tercPath, string simcPath, string ulicPath);
        ICollection<Location> GetLocations(string simcPath);
        ICollection<Borough> GetBoroughs(string tercPath);
        ICollection<Township> GetTownships(string tercPath);
        ICollection<Voivodeship> GetVoivodeships(string tercPath);
    }
}