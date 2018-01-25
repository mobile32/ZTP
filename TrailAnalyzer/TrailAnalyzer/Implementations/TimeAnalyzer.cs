using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrailAnalyzer.Interfaces;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Implementations
{
    public class TimeAnalyzer :ITimeAnalyzer
    {
        public double TotalTrackTime(Trail trail)
        {
            return (trail.Points.Max(t => t.Time) - trail.Points.Min(t => t.Time)).Seconds;
        }

        public double ClimnbingTime(Trail trail)
        {
            return trail.Points
                .Select((t, i) => trail.Points[i + 1].Elevation - t.Elevation > 0 ?
                    (trail.Points[i + 1].Time - t.Time) : new TimeSpan(0))
                .Sum(r => r.Seconds);
        }

        public double DescentTime(Trail trail)
        {
            return trail.Points
                .Select((t, i) => t.Elevation - trail.Points[i + 1].Elevation > 0 ?
                    (trail.Points[i + 1].Time - t.Time) : new TimeSpan(0))
                .Sum(r => r.Seconds);
        }

        public double FlatTime(Trail trail)
        {
            return trail.Points
                .Select((t, i) => t.Elevation - trail.Points[i + 1].Elevation == 0 ?
                    (trail.Points[i + 1].Time - t.Time) : new TimeSpan(0))
                .Sum(r => r.Seconds);
        }
    }
}
