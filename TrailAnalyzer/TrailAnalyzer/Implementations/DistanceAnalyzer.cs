using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrailAnalyzer.Common;
using TrailAnalyzer.Interfaces;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Implementations
{
    public class DistanceAnalyzer : IDistanceAnalyzer
    {
        private double TotalDistance(Trail trail)
        {
            return trail.Points.Select((t, i) => DistanceBeetwenTwoPoints(t, trail.Points[i + 1])).Sum();
        }

        private double DistanceBeetwenTwoPoints(Point start, Point end)
        {
            var lat = (end.Latitude - start.Latitude).ToRadians();
            var lng = (end.Longitude - start.Longitude).ToRadians();

            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                     Math.Cos(start.Latitude.ToRadians()) * Math.Cos(end.Latitude.ToRadians()) *
                     Math.Sin(lng / 2) * Math.Sin(lng / 2);
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));

            return 6371 * h2;
        }
    }
}
