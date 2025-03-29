using System;

public struct Color
{
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
}

public static class Gap
{
    public static double Clamp(double value, double min, double max)
    {
        return Math.Max(min, Math.Min(max, value));
    }
}
