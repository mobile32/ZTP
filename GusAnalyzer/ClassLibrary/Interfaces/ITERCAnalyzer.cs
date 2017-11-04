using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Interfaces
{
    public interface ITERCAnalyzer
    {
        TERCData GetData(string tercXMLPath);
        IEnumerable<Voivodeship> GetVoivodeships(string tercXMLPath);
        IEnumerable<Township> GetTownships(string tercXMLPath);
        IEnumerable<Borough> GetBoroughs(string tercXMLPath);
    }
}