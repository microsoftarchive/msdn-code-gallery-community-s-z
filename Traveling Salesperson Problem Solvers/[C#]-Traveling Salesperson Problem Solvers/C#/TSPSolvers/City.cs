using System;

namespace TSPSolvers
{
    class City
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Id { get; set; }

        public City(double x, double y, int id)
        {
            X = x;
            Y = y;
            Id = id;
        }

        public double Distance(City other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}