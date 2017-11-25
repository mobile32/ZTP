using System;
using System.Collections.Generic;
using System.Text;

namespace TrailAnalyzer.Common
{
    public static class MathOperations
    {
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
