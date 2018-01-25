using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrailAnalyzer.Helpers;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Interfaces
{
    public interface ISpeedAnalyzer
    {
        double MinimumSpeed(Trail trail);
        double MaxiumumSpeed(Trail trail);
        double AverageSpeed(Trail trail);
        double AverageClimbingSpeed(Trail trail);
        double AverageDescentSpeed(Trail trail);
        double AverageFlatSpeed(Trail trail);
    }
}
