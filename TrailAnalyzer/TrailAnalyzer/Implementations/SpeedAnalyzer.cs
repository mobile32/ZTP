using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrailAnalyzer.Helpers;
using TrailAnalyzer.Interfaces;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Implementations
{
    public class SpeedAnalyzer : ISpeedAnalyzer
    {
        public double MinimumSpeed(Trail trail)
        {
            return trail.Points
                .Select((t, i) => MathHelper.DistanceBeetwenTwoPoints(t, trail.Points[i + 1]) /
                                  (trail.Points[i + 1].Time - t.Time).TotalSeconds)
                .Min();
        }

        public double MaxiumumSpeed(Trail trail)
        {
            return trail.Points
                .Select((t, i) => MathHelper.DistanceBeetwenTwoPoints(t, trail.Points[i + 1]) /
                                  (trail.Points[i + 1].Time - t.Time).TotalSeconds)
                .Max();
        }

        public double AverageSpeed(Trail trail)
        {
            return trail.Points
                .Select((t, i) => MathHelper.DistanceBeetwenTwoPoints(t, trail.Points[i + 1]) /
                                  (trail.Points[i + 1].Time - t.Time).TotalSeconds)
                .Average();
        }

        public double AverageClimbingSpeed(Trail trail)
        {
            return trail.Points
                .Select((t, i) => (trail.Points[i + 1].Elevation - t.Elevation > 0 ?
                                      MathHelper.DistanceBeetwenTwoPoints(t, trail.Points[i + 1]) : 0) /
                                  (trail.Points[i + 1].Time - t.Time).TotalSeconds)
                .Where(s => s != 0)
                .Average();
        }

        public double AverageDescentSpeed(Trail trail)
        {
            return trail.Points
                .Select((t, i) => (t.Elevation - trail.Points[i + 1].Elevation > 0 ?
                                      MathHelper.DistanceBeetwenTwoPoints(t, trail.Points[i + 1]) : 0) /
                                  (trail.Points[i + 1].Time - t.Time).TotalSeconds)
                .Where(s => s != 0)
                .Average();
        }

        public double AverageFlatSpeed(Trail trail)
        {
            return trail.Points
                .Select((t, i) => (t.Elevation - trail.Points[i + 1].Elevation == 0 ?
                                      MathHelper.DistanceBeetwenTwoPoints(t, trail.Points[i + 1]) : 0) /
                                  (trail.Points[i + 1].Time - t.Time).TotalSeconds)
                .Where(s => s != 0)
                .Average();
        }
    }
}
