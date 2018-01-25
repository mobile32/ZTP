using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrailAnalyzer.Common;
using TrailAnalyzer.Helpers;
using TrailAnalyzer.Interfaces;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Implementations
{
    public class DistanceAnalyzer : IDistanceAnalyzer
    {
        public double TotalDistance(Trail trail)
        {
            return trail.Points.Select((t, i) => MathHelper.DistanceBeetwenTwoPoints(t, trail.Points[i + 1])).Sum();
        }

        public double ClimbingDistance(Trail trail)
        {
            return trail.Points
                .Select((t, i) => trail.Points[i + 1].Elevation - t.Elevation > 0 ?
                    MathHelper.DistanceBeetwenTwoPoints(t, trail.Points[i + 1]) : 0)
                .Sum();
        }

        public double DescentDistance(Trail trail)
        {
            return trail.Points
                .Select((t, i) => t.Elevation - trail.Points[i + 1].Elevation > 0 ?
                    MathHelper.DistanceBeetwenTwoPoints(t, trail.Points[i + 1]) : 0)
                .Sum();
        }

        public double FlatDistance(Trail trail)
        {
            return trail.Points
                .Select((t, i) => t.Elevation - trail.Points[i + 1].Elevation == 0 ?
                    MathHelper.DistanceBeetwenTwoPoints(t, trail.Points[i + 1]) : 0)
                .Sum();
        }
    }
}
