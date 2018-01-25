using System;
using System.Collections.Generic;
using System.Text;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Interfaces
{
    public interface IDistanceAnalyzer
    {
        double TotalDistance(Trail trail);
        double ClimbingDistance(Trail trail);
        double DescentDistance(Trail trail);
        double FlatDistance(Trail trail);
    }
}
