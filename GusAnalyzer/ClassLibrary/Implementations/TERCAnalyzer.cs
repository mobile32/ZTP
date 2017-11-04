using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Implementations
{
    public class TERCAnalyzer : ITERCAnalyzer
    {
        public TERCData GetData(string tercXMLPath)
        {
            var xml = XDocument.Load(tercXMLPath);

            var all = xml.Descendants("row");

            var voivodeships = GetVoivodeships(all).ToList();
            var townships = GetTownships(all).ToList();
            var boroughs = GetBoroughs(all).ToList();
            
            return new TERCData
            {
                Voivodeships = voivodeships,
                Townships = townships,
                Boroughs = boroughs
            };
        }

        public IEnumerable<Voivodeship> GetVoivodeships(string tercXMLPath)
        {
            return GetVoivodeships(XDocument.Load(tercXMLPath).Descendants("row"));
        }

        private IEnumerable<Voivodeship> GetVoivodeships(IEnumerable<XElement> nodes)
        {
            var voivodeshipNodes = nodes.Where(x =>
                string.IsNullOrWhiteSpace(x.XPathSelectElement("POW").Value) &&
                string.IsNullOrWhiteSpace(x.XPathSelectElement("GMI").Value));

            return voivodeshipNodes.Select(x => new Voivodeship
            {
                Id = int.Parse(x.XPathSelectElement("WOJ").Value),
                Name = x.XPathSelectElement("NAZWA").Value,
                AdditionalName = x.XPathSelectElement("NAZWA_DOD").Value
            }).ToList();
        }

        public IEnumerable<Township> GetTownships(string tercXMLPath)
        {
            return GetTownships(XDocument.Load(tercXMLPath).Descendants("row"));
        }

        private IEnumerable<Township> GetTownships(IEnumerable<XElement> nodes)
        {
            var townshipNodes = nodes.Where(x =>
                !string.IsNullOrWhiteSpace(x.XPathSelectElement("POW").Value) &&
                string.IsNullOrWhiteSpace(x.XPathSelectElement("GMI").Value));

            return townshipNodes.Select(x => new Township
            {
                Id = int.Parse(x.XPathSelectElement("POW").Value),
                Name = x.XPathSelectElement("NAZWA").Value,
                AdditionalName = x.XPathSelectElement("NAZWA_DOD").Value,
                VoivodeshipId = int.Parse(x.XPathSelectElement("WOJ").Value)
            });
        }


        public IEnumerable<Borough> GetBoroughs(string tercXMLPath)
        {
            return GetBoroughs(XDocument.Load(tercXMLPath).Descendants("row"));
        }

        private IEnumerable<Borough> GetBoroughs(IEnumerable<XElement> nodes)
        {
            var boroughNodes = nodes.Where(x => !string.IsNullOrWhiteSpace(x.XPathSelectElement("GMI").Value));
            return boroughNodes.Select(x => new Borough
            {
                Id = int.Parse(x.XPathSelectElement("POW").Value),
                Name = x.XPathSelectElement("NAZWA").Value,
                AdditionalName = x.XPathSelectElement("NAZWA_DOD").Value,
                VoivodeshipId = int.Parse(x.XPathSelectElement("WOJ").Value),
                TownshipId = int.Parse(x.XPathSelectElement("POW").Value)
            });
        }
    }
}