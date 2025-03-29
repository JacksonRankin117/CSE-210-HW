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
    public static Vec3 operator -(Vec3 v) => new Vec3(-v.E[0], -v.E[1], -v.E[2]);

    public double this[int i] {
        get => E[i];
        set => E[i] = value;
    }

    public static Color operator +(Color u, Color v) {
        return new Color(u.E[0] + v.E[0], u.E[1] + v.E[1], u.E[2] + v.E[2]);
    }

    public static Color operator -(Color u, Color v) {
        return new Vec3(u.E[0] - v.E[0], u.E[1] - v.E[1], u.E[2] - v.E[2]);
    }

    public static Color operator*(Color u, Color v) {
    return vec3(u.e[0] * v.e[0], u.e[1] * v.e[1], u.e[2] * v.e[2]);
}

    public static Color operator *(Color v, double t) {
        return new Color(v.E[0] * t, v.E[1] * t, v.E[2] * t);
    }

    public static Color operator *(double t, Color v) {
        return v * t;
    }

    public static Color operator /(Color v, double t) {
        return v * (1 / t);
    }

    public static Color Random() {
        return new Vec3(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
    }

    public static Color Random(double min, double max) {
        // Ensure that the random values are scaled between min and max
        return new Vec3(
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
