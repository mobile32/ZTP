using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace TrailAnalyzer.Models
{
    public class Trail
    {
        public string Name { get; set; }
        public List<Point> Points { get; set; }
    }
}
