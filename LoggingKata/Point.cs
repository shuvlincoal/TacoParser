using System;
using System.Collections.Generic;

namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public static implicit operator Point(HashSet<Point> v)
        {
            throw new NotImplementedException();
        }
    }
}