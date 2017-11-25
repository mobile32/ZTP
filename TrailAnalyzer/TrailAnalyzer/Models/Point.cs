using System;
using System.Collections.Generic;
using System.Text;

namespace TrailAnalyzer.Models
{
    public class Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Elevation { get; set; }
        public DateTime Time { get; set; }
    }
}
