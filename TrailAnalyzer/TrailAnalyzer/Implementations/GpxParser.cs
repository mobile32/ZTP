using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TrailAnalyzer.Interfaces;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Implementations
{
    public class GpxParser : IGpxParser
    {
        public Trail ParseTrail(string gpxContent)
        {
            var xDoc = XDocument.Parse(gpxContent);

            var trail = new Trail()
            {
                Name = xDoc.Element("trk").Element("name").ToString()
            };

            foreach (var node in xDoc.Descendants("trkseg").Elements("trkpt"))
            {
                trail.Points.Add(new Point
                {
                    Longitude = double.Parse(node.Attribute("lon").ToString()),
                    Latitude = double.Parse(node.Attribute("lat").ToString()),
                    Elevation = double.Parse(node.Element("ele").ToString()),
                    Time = DateTime.Parse(node.Elements("time").ToString())
                });

            }

            return trail;
        }

    }
}
