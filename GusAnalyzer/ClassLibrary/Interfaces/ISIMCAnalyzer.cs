using System.Collections;
using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Interfaces
{
    public interface ISIMCAnalyzer
    {
        IEnumerable<Location> GetLocations(string simcPath);
    }
}