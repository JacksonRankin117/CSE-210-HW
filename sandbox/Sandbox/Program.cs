using System;
using System.Drawing;

namespace RayTracing
{
    public class Vec3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        // Method for dot product
        public double Dot(Vec3 other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        // Overload the '-' operator for Vec3 subtraction
        public static Vec3 operator -(Vec3 v1, Vec3 v2)
        {
            return new Vec3
            {
                X = v1.X - v2.X,
                Y = v1.Y - v2.Y,
                Z = v1.Z - v2.Z
            };
        }

        // Method to get the unit vector
        public Vec3 UnitVector()
        {
            double magnitude = Math.Sqrt(X * X + Y * Y + Z * Z);
            return new Vec3 { X = X / magnitude, Y = Y / magnitude, Z = Z / magnitude };
        }

        // Overload the '*' operator for multiplying Vec3 with a scalar
        public static Vec3 operator *(double scalar, Vec3 vec)
        {
            return new Vec3
            {
                X = scalar * vec.X,
                Y = scalar * vec.Y,
                Z = scalar * vec.Z
            };
        }

        // Convert Vec3 to Point3
        public Point3 ToPoint3()
        {
            return new Point3 { X = X, Y = Y, Z = Z };
        }
    }

    public class Point3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public static class Utils
    {
        // Method to generate a random double between a range
        public static double RandomDouble(double minValue, double maxValue)
        {
            Random random = new Random();
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        // Method to output colors (e.g., for debugging or logging)
        public static void WriteColor(Color color)
        {
            Console.WriteLine($"Color: {color.R}, {color.G}, {color.B}");
        }
    }

    // Example usage inside a RayTracing class or other relevant area
    public class RayTracer
    {
        public void Trace()
        {
            Vec3 vec1 = new Vec3 { X = 1, Y = 2, Z = 3 };
            Vec3 vec2 = new Vec3 { X = 4, Y = 5, Z = 6 };

            // Dot product
            double dotProduct = vec1.Dot(vec2);
            Console.WriteLine($"Dot product: {dotProduct}");

            // Unit vector
            Vec3 unitVec = vec1.UnitVector();
            Console.WriteLine($"Unit Vector: {unitVec.X}, {unitVec.Y}, {unitVec.Z}");

            // Random value
            double randomValue = Utils.RandomDouble(1.0, 10.0);
            Console.WriteLine($"Random Value: {randomValue}");

            // Color output
            Color color = Color.Red;
            Utils.WriteColor(color);

            // Vec3 subtraction
            Vec3 resultVec = vec1 - vec2;
            Console.WriteLine($"Vec3 subtraction result: {resultVec.X}, {resultVec.Y}, {resultVec.Z}");

            // Vec3 scalar multiplication
            Vec3 scaledVec = 0.5 * vec1;
            Console.WriteLine($"Scaled Vec3: {scaledVec.X}, {scaledVec.Y}, {scaledVec.Z}");

            // Vec3 to Point3 conversion
            Point3 point = vec1.ToPoint3();
            Console.WriteLine($"Point3: {point.X}, {point.Y}, {point.Z}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        RayTracing.RayTracer rayTracer = new RayTracing.RayTracer();
        rayTracer.Trace();
    }
}
