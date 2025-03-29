using System;

// Constants
public static class RTWeekend
{
    public const double Infinity = double.PositiveInfinity;
    public const double Pi = 3.1415926535897932385;

    // Utility Functions
    public static double DegreesToRadians(double degrees)
    {
        return degrees * Pi / 180.0;
    }

    public static double RandomDouble()
    {
        // Returns a random real in [0,1).
        return new Random().NextDouble();
    }

    public static double RandomDouble(double min, double max)
    {
        // Returns a random real in [min,max).
        return min + (max - min) * RandomDouble();
    }
}
