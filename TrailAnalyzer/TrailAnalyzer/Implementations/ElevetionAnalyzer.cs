using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrailAnalyzer.Interfaces;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Implementations
{
    public class ElevetionAnalyzer : IElevationAnalyzer
    {
        public double MinimalElevation(Trail trail)
        {
            return trail.Points.Min(t => t.Elevation);
        }

        public double MaximumElevation(Trail trail)
        {
            return trail.Points.Max(t => t.Elevation);
        }

        public double AverageElevation(Trail trail)
        {
            return trail.Points.Average(t => t.Elevation);
        }

        public double TotalClimbing(Trail trail)
        {
            return trail.Points
                .Select((t, i) => trail.Points[i + 1].Elevation - t.Elevation)
                .Where(e => e > 0)
                .Sum();
        }

        public double TotalDescent(Trail trail)
        {
            return trail.Points
                .Select((t, i) => t.Elevation - trail.Points[i + 1].Elevation)
                .Where(e => e > 0)
                .Sum();
        }

        public double FinalBalance(Trail trail)
        {
            return TotalClimbing(trail) - TotalDescent(trail);
        }
    }
}
