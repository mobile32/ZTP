using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Implementations
{
    public class SIMCAnalyzer: ISIMCAnalyzer
    {
        public IEnumerable<Location> GetLocations(string simcPath)
        {
            var xml = XDocument.Load(simcPath);

            var all = xml.Descendants("row");

            return all.Select(x => new Location
            {
                Name = x.XPathSelectElement("NAZWA").Value,
                BoroughId = int.Parse(x.XPathSelectElement("GMI").Value),
                TownshipId = int.Parse(x.XPathSelectElement("POW").Value),
                VoivodeshipId = int.Parse(x.XPathSelectElement("WOJ").Value),
                Type = (LocationType)int.Parse(x.XPathSelectElement("RM").Value),
                Symbol = x.XPathSelectElement("SYM").Value
            });
        }
    }
}