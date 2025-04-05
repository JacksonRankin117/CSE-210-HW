using System;

public struct Color
{
    private static readonly Random rand = new Random();

    public double R { get; }
    public double G { get; }
    public double B { get; }

    public Color(double r, double g, double b)
    {
        R = r;
        G = g;
        B = b;
    }

    private static double LinearToGamma(double linear)
    {
        if (linear <= 0.0031308)
            return 12.92 * linear;
        else
            return 1.055 * Math.Pow(linear, 1.0 / 2.4) - 0.055;
    }


    public static void WriteColor(System.IO.TextWriter writer, Color pixelColor)
    {
        double r = LinearToGamma(pixelColor.R);
        double g = LinearToGamma(pixelColor.G);
        double b = LinearToGamma(pixelColor.B);

        // Clamp values and scale to 8-bit (0-255) range
        int rByte = (int)(255.999 * Math.Clamp(r, 0.0, 1.0));
        int gByte = (int)(255.999 * Math.Clamp(g, 0.0, 1.0));
        int bByte = (int)(255.999 * Math.Clamp(b, 0.0, 1.0));

        writer.WriteLine($"{rByte} {gByte} {bByte}");
    }

    public static Color operator -(Color v) => new Color(-v.R, -v.G, -v.B);
    public static Color operator +(Color u, Color v) => new Color(u.R + v.R, u.G + v.G, u.B + v.B);
    public static Color operator -(Color u, Color v) => new Color(u.R - v.R, u.G - v.G, u.B - v.B);
    public static Color operator *(Color u, Color v) => new Color(u.R * v.R, u.G * v.G, u.B * v.B);
    public static Color operator *(Color v, double t) => new Color(v.R * t, v.G * t, v.B * t);
    public static Color operator *(double t, Color v) => v * t;

    public static Color operator /(Color v, double t) {
        return v * (1 / t);
    }

    public static Color Random() {
        return new Color(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
    }

    public static Color Random(double min, double max) {
        return new Color(
            min + (max - min) * rand.NextDouble(),
            min + (max - min) * rand.NextDouble(),
            min + (max - min) * rand.NextDouble()
        );
    }
}
