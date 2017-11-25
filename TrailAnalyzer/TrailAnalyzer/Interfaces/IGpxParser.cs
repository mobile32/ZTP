using System;
using System.Collections.Generic;
using System.Text;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Interfaces
{
    interface IGpxParser
    {
        Trail ParseTrail(string gpxContent);
    }
}
