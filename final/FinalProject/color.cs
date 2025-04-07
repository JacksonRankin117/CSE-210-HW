using System;

public struct Color
{
    private static readonly Random _rand = new Random();

    public double _r { get; }
    public double _g { get; }
    public double _b { get; }

    public Color(double r, double g, double b)
    {
        _r = r;
        _g = g;
        _b = b;
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
        double r = LinearToGamma(pixelColor._r);
        double g = LinearToGamma(pixelColor._g);
        double b = LinearToGamma(pixelColor._b);

        // Clamp values and scale to 8-bit (0-255) range
        int rByte = (int)(255.999 * Math.Clamp(r, 0.0, 1.0));
        int gByte = (int)(255.999 * Math.Clamp(g, 0.0, 1.0));
        int bByte = (int)(255.999 * Math.Clamp(b, 0.0, 1.0));

        writer.WriteLine($"{rByte} {gByte} {bByte}");
    }

    public static Color operator -(Color v) => new Color(-v._r, -v._g, -v._b);
    public static Color operator +(Color u, Color v) => new Color(u._r + v._r, u._g + v._g, u._b + v._b);
    public static Color operator -(Color u, Color v) => new Color(u._r - v._r, u._g - v._g, u._b - v._b);
    public static Color operator *(Color u, Color v) => new Color(u._r * v._r, u._g * v._g, u._b * v._b);
    public static Color operator *(Color v, double t) => new Color(v._r * t, v._g * t, v._b * t);
    public static Color operator *(double t, Color v) => v * t;

    public static Color operator /(Color v, double t) {
        return v * (1 / t);
    }

    public static Color Random() {
        return new Color(_rand.NextDouble(), _rand.NextDouble(), _rand.NextDouble());
    }

    public static Color Random(double min, double max) {
        return new Color(
            min + (max - min) * _rand.NextDouble(),
            min + (max - min) * _rand.NextDouble(),
            min + (max - min) * _rand.NextDouble()
        );
    }
}
