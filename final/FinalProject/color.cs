using System;

public struct Color
{
    public static Random rand = new Random();

    public double R { get; }
    public double G { get; }
    public double B { get; }

    public Color(double r, double g, double b)
    {
        R = r;
        G = g;
        B = b;
    }

    private static double LinearToGamma(double linearComponent)
    {
        return linearComponent > 0 ? Math.Sqrt(linearComponent) : 0;
    }

    public static void WriteColor(System.IO.TextWriter writer, Color pixelColor)
    {
        double r = LinearToGamma(pixelColor.R);
        double g = LinearToGamma(pixelColor.G);
        double b = LinearToGamma(pixelColor.B);

        // Clamp values to [0, 0.999] and scale to byte range [0, 255]
        int rByte = (int)(256 * Gap.Clamp(r, 0.0, 0.999));
        int gByte = (int)(256 * Gap.Clamp(g, 0.0, 0.999));
        int bByte = (int)(256 * Gap.Clamp(b, 0.0, 0.999));

        // Write out the pixel color components
        writer.WriteLine($"{rByte} {gByte} {bByte}");
    }
    public static Color operator -(Color v) {
        return new Color(-v.R, -v.G, -v.B);
    }

    // Vector operator override
    public static Color operator +(Color u, Color v) {
        return new Color(u.R + v.R, u.G + v.G, u.B + v.B);
    }

    public static Color operator -(Color u, Color v) {
        return new Color(u.R - v.R, u.G - v.G, u.B - v.B);
    }

    public static Color operator*(Color u, Color v) {
        return new Color(u.R * v.R, u.G * v.G, u.B * v.B);
    }

    public static Color operator *(Color v, double t) {
        return new Color(v.R * t, v.G * t, v.B * t);
    }

    public static Color operator *(double t, Color v) {
        return v * t;
    }

    public static Color operator /(Color v, double t) {
        return v * (1 / t);
    }

    public static Color Random() {
        return new Color(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
    }

    public static Color Random(double min, double max) {
        // Ensure that the random values are scaled between min and max
        return new Color(
            min + (max - min) * rand.NextDouble(),
            min + (max - min) * rand.NextDouble(),
            min + (max - min) * rand.NextDouble()
        );
    }
}

public static class Gap
{
    public static double Clamp(double value, double min, double max)
    {
        return Math.Max(min, Math.Min(max, value));
    }
}
